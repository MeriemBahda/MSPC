﻿// Licensed to the Genometric organization (https://github.com/Genometric) under one or more agreements.
// The Genometric organization licenses this file to you under the GNU General Public License v3.0 (GPLv3).
// See the LICENSE file in the project root for more information.

using Genometric.MSPC.Model;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace Genometric.MSPC.CLI.Tests
{
    public class Main
    {
        [Fact]
        public void ErrorIfLessThanTwoSamplesAreGiven()
        {
            // Arrange & Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main("-i rep1.bed -r bio -w 1E-2 -s 1E-8".Split(' '));

                // Assert
                Assert.Equal("At least two samples are required; 1 is given.\r\nMSPC cannot continue.\r\n", sw.ToString());
            }
        }

        [Fact]
        public void ErrorIfARequiredArgumentIsMissing()
        {
            // Arrange & Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main("-i rep1.bed -i rep2.bed -w 1E-2 -s 1E-8".Split(' '));

                // Assert
                Assert.Equal("The following required arguments are missing: r|replicate; \r\nMSPC cannot continue.\r\n", sw.ToString());
            }
        }

        [Fact]
        public void ErrorIfASpecifiedFileIsMissing()
        {
            // Arrange & Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main("-i rep1.bed -i rep2.bed -r bio -w 1E-2 -s 1E-8".Split(' '));

                // Assert
                Assert.Equal("Missing file: rep1.bed\r\nMSPC cannot continue.\r\n", sw.ToString());
            }
        }

        [Fact]
        public void SuccessfulAnalysis()
        {
            // Arrange
            var rep1 = Path.GetTempPath() + Guid.NewGuid().ToString() + ".bed";
            FileStream stream = File.Create(rep1);
            using (StreamWriter writter = new StreamWriter(stream))
                writter.WriteLine("chr1\t10\t20\tmspc_peak_1\t100.0");

            var rep2 = Path.GetTempPath() + Guid.NewGuid().ToString() + ".bed";
            stream = File.Create(rep2);
            using (StreamWriter writter = new StreamWriter(stream))
                writter.WriteLine("chr1\t8\t22\tmspc_peak_2\t110.0");

            // Act
            string msg;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(String.Format("-i {0} -i {1} -r bio -w 1E-2 -s 1E-8", rep1, rep2).Split(' '));
                msg = sw.ToString();
            }

            // Assert
            Assert.Contains("All processes successfully finished [Analysis ET: ", msg);
        }
    }
}
