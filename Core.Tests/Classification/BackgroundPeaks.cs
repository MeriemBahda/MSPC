﻿// Licensed to the Genometric organization (https://github.com/Genometric) under one or more agreements.
// The Genometric organization licenses this file to you under the GNU General Public License v3.0 (GPLv3).
// See the LICENSE file in the project root for more information.

using Genometric.GeUtilities.IntervalParsers;
using Genometric.GeUtilities.IntervalParsers.Model.Defaults;
using Genometric.MSPC;
using Genometric.MSPC.Core.Model;
using Genometric.MSPC.Model;
using System.Collections.ObjectModel;
using Xunit;

namespace Core.Tests.Base
{
    public class BackgroundPeaks
    {
        private ReadOnlyDictionary<uint, Result<ChIPSeqPeak>> GenerateAndProcessBackgroundPeaks()
        {
            var sA = new BED<ChIPSeqPeak>();
            sA.Add(new ChIPSeqPeak() { Left = 10, Right = 20, Value = 1e-2 }, "chr1", '*');

            var sB = new BED<ChIPSeqPeak>();
            sB.Add(new ChIPSeqPeak() { Left = 5, Right = 12, Value = 1e-4 }, "chr1", '*');

            var mspc = new MSPC<ChIPSeqPeak>();
            mspc.AddSample(0, sA);
            mspc.AddSample(1, sB);

            var config = new Config(ReplicateType.Biological, 1e-4, 1e-8, 1e-4, 2, 1F, MultipleIntersections.UseLowestPValue);

            // Act
            var res = mspc.Run(config);

            return res;
        }

        [Fact]
        public void AssignBackgroundAttribute()
        {
            // Arrange & Act
            var res = GenerateAndProcessBackgroundPeaks();

            // Assert
            foreach (var s in res)
                Assert.True(s.Value.Chromosomes["chr1"].GetInitialClassifications(Attributes.Background).Count == 1);
        }

        [Fact]
        public void BackgroundPeaksShouldNotHaveAnyOtherAttributes()
        {
            // Arrange & Act
            var res = GenerateAndProcessBackgroundPeaks();

            // Assert
            foreach (var s in res)
                Assert.True(
                    s.Value.Chromosomes["chr1"].GetInitialClassifications(Attributes.Weak).Count == 0 &&
                    s.Value.Chromosomes["chr1"].GetInitialClassifications(Attributes.Stringent).Count == 0 &&
                    s.Value.Chromosomes["chr1"].Get(Attributes.Confirmed).Count == 0 &&
                    s.Value.Chromosomes["chr1"].Get(Attributes.Discarded).Count == 0 &&
                    s.Value.Chromosomes["chr1"].Get(Attributes.TruePositive).Count == 0 &&
                    s.Value.Chromosomes["chr1"].Get(Attributes.FalsePositive).Count == 0);
        }

        [Fact]
        public void BackgroundPeakAreNotConsideredDiscarded()
        {
            // Arrange & Act
            var res = GenerateAndProcessBackgroundPeaks();

            // Assert
            foreach (var s in res)
                Assert.True(s.Value.Chromosomes["chr1"].Get(Attributes.Discarded).Count == 0);
        }

        [Fact]
        public void BackgroundPeaksAreNotConsideredConfirmed()
        {
            // Arrange & Act
            var res = GenerateAndProcessBackgroundPeaks();

            // Assert
            foreach (var s in res)
                Assert.True(s.Value.Chromosomes["chr1"].Get(Attributes.Confirmed).Count == 0);
        }
    }
}
