﻿using Genometric.GeUtilities.IntervalParsers;
using Genometric.GeUtilities.IntervalParsers.Model.Defaults;
using Genometric.MSPC;
using Genometric.MSPC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xunit;

namespace Core.Tests.Example
{
    public class Eg1
    {
        private readonly ChIPSeqPeak r11 = new ChIPSeqPeak() { Left = 3, Right = 13, Name = "11", Value = 1e-6, HashKey = 1 };
        private readonly ChIPSeqPeak r12 = new ChIPSeqPeak() { Left = 21, Right = 32, Name = "12", Value = 1e-12, HashKey = 2 };
        private readonly ChIPSeqPeak r21 = new ChIPSeqPeak() { Left = 10, Right = 25, Name = "21", Value = 1e-7, HashKey = 3 };
        private readonly ChIPSeqPeak r22 = new ChIPSeqPeak() { Left = 30, Right = 37, Name = "22", Value = 1e-5, HashKey = 4 };
        private readonly ChIPSeqPeak r23 = new ChIPSeqPeak() { Left = 41, Right = 48, Name = "23", Value = 1e-6, HashKey = 5 };
        private readonly ChIPSeqPeak r31 = new ChIPSeqPeak() { Left = 0, Right = 4, Name = "31", Value = 1e-6, HashKey = 6 };
        private readonly ChIPSeqPeak r32 = new ChIPSeqPeak() { Left = 8, Right = 17, Name = "32", Value = 1e-12, HashKey = 7 };
        private readonly ChIPSeqPeak r33 = new ChIPSeqPeak() { Left = 51, Right = 58, Name = "33", Value = 1e-18, HashKey = 8 };

        private MSPC<ChIPSeqPeak> GenerateAndAddEg1Peaks()
        {
            var sA = new BED<ChIPSeqPeak>();
            sA.Add(r11, "chr1", '*');
            sA.Add(r12, "chr1", '*');

            var sB = new BED<ChIPSeqPeak>();
            sB.Add(r21, "chr1", '*');
            sB.Add(r22, "chr1", '*');
            sB.Add(r23, "chr1", '*');

            var sC = new BED<ChIPSeqPeak>();
            sC.Add(r31, "chr1", '*');
            sC.Add(r32, "chr1", '*');
            sC.Add(r33, "chr1", '*');

            var mspc = new MSPC<ChIPSeqPeak>();
            mspc.AddSample(0, sA);
            mspc.AddSample(1, sB);
            mspc.AddSample(2, sC);
            return mspc;
        }

        [Fact]
        public void AnalyzeTecReps()
        {
            // Arrange & Act
            var mspc = GenerateAndAddEg1Peaks();
            var config = new Config(ReplicateType.Technical, 1e-4, 1e-8, 1e-4, 3, 1F, MultipleIntersections.UseLowestPValue);
            var res = mspc.Run(config);

            // TODO: this step should not be necessary; remove it after the Results class is updated.
            ///foreach (var rep in res)
            ///    rep.Value.ReadOverallStats();

            // TODO: check for the counts in sets: if you expect one peak in the set, there must be exactly one peak in that set.

            // Assert
            var s1 = res[0];
            var qres = s1.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r11) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakConfirmed);

            qres = s1.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r11) == 0).Value;
            Assert.True(qres == null);

            qres = s1.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r12) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.StringentDiscardedC);

            qres = s1.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r12) == 0).Value;
            Assert.True(qres == null);
            

            var s2 = res[1];
            qres = s2.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r21) == 0).Value;
            Assert.True(qres == null);

            qres = s2.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r22) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakDiscardedC);

            qres = s2.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r23) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakDiscardedC);

            qres = s2.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r21) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakConfirmed);
            // TODO: check for the count of stringent discarded and stringent confirmed.

            var s3 = res[2];
            qres = s3.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r23) == 0).Value;
            Assert.True(qres == null);

            qres = s3.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r33) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.StringentDiscardedC);

            qres = s3.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r32) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.StringentConfirmed);

            Assert.True(s1.Chromosomes["chr1"].R_j__o.Count == 1);
            Assert.True(s2.Chromosomes["chr1"].R_j__o.Count == 1);
            Assert.True(s3.Chromosomes["chr1"].R_j__o.FirstOrDefault(x => x.peak.CompareTo(r32) == 0) != null);
        }

        [Fact]
        public void AnalyzeBioReps()
        {
            // Arrange & Act
            var mspc = GenerateAndAddEg1Peaks();
            var config = new Config(ReplicateType.Technical, 1e-4, 1e-8, 1e-4, 2, 1F, MultipleIntersections.UseLowestPValue);
            var res = mspc.Run(config);

            // TODO: this step should not be necessary; remove it after the Results class is updated.
            ///foreach (var rep in res)
            ///    rep.Value.ReadOverallStats();

            // TODO: check for the counts in sets: if you expect one peak in the set, there must be exactly one peak in that set.

            // Assert
            var s1 = res[0];
            Assert.True(s1.Chromosomes["chr1"].R_j__d.Count == 0);

            var qres = s1.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r11) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakConfirmed);

            qres = s1.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r12) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.StringentConfirmed);


            var s2 = res[1];
            qres = s2.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r23) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakDiscardedC);

            qres = s2.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r21) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakConfirmed);

            qres = s2.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r22) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakConfirmed);
            // TODO: check for the count of stringent discarded and stringent confirmed.

            var s3 = res[2];
            /// Assert.True(s3.total__wdc + s3.total__wdt == 0);

            qres = s3.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r31) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.WeakConfirmed);

            qres = s3.Chromosomes["chr1"].R_j__d.FirstOrDefault(x => x.Value.peak.CompareTo(r33) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.StringentDiscardedC);

            qres = s3.Chromosomes["chr1"].R_j__c.FirstOrDefault(x => x.Value.peak.CompareTo(r32) == 0).Value;
            Assert.True(qres != null);
            Assert.True(qres.classification == PeakClassificationType.StringentConfirmed);

            Assert.True(s1.Chromosomes["chr1"].R_j__o.Count == 2);
            Assert.True(s2.Chromosomes["chr1"].R_j__o.Count == 2);
            Assert.True(s3.Chromosomes["chr1"].R_j__o.Count == 2);
        }
    }
}