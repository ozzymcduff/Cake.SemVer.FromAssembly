using System;
using Cake.Core;
using Cake.Testing;
using Xunit;

namespace  Cake.SemVer.FromBinary.Tests
{
    public class SemVerMagnitudeRunnerTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsType<ArgumentNullException>(result);
            Assert.Equal("settings", ((ArgumentNullException)result).ParamName);
        }

        [Fact]
        public void Should_Throw_If_Executable_Was_Not_Found()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsType<CakeException>(result);
            Assert.Equal("SynVer: Could not locate executable.", result.Message);
        }

        [Theory]
        [InlineData("/bin/tools/SynVer/SynVer.exe", "/bin/tools/SynVer/SynVer.exe")]
        [InlineData("./tools/SynVer/SynVer.exe", "/Working/tools/SynVer/SynVer.exe")]
        public void Should_Use_Tfx_Executable_From_Tool_Path_If_Provided(string toolPath, string expected)
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.Settings.ToolPath = toolPath;
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Path.FullPath);
        }

        [Fact]
        public void Should_Throw_If_Process_Was_Not_Started()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.GivenProcessCannotStart();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsType<CakeException>(result);
            Assert.Equal("SynVer: Process was not started.", result.Message);
        }

        [Fact]
        public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.GivenProcessExitsWithCode(1);

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsType<CakeException>(result);
            Assert.StartsWith(@"SynVer: Process returned an error (exit code 1)", result.Message);
        }

        [Fact]
        public void Should_Find_Executable_If_Tool_Path_Not_Provided()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("/Working/tools/SynVer.exe", result.Path.FullPath);
        }

        [Fact]
        public void Should_Throw_If_Original_File_Is_Null()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.Original = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsType<ArgumentNullException>(result);
            Assert.Equal("original", ((ArgumentNullException)result).ParamName);
        }

     
        [Fact]
        public void Should_Add_Output_To_Arguments_If_Set()
        {
            // Given
            var fixture = new SemVerMagnitudeRunnerFixture();
            fixture.Settings.Output = "c:/temp/test.output";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(@"--magnitude ""c:\temp\original.dll"" ""c:\temp\new.dll"" --output ""c:\temp\test.output""", result.Args);
        }
    }
}
