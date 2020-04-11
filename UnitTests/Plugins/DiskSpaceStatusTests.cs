using System;
using System.Diagnostics.CodeAnalysis;
using HealthCheck;
using HealthCheck.Plugins;
using Moq;
using Xunit;

namespace UnitTests.Plugins
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1600:ElementsMustBeDocumented",
        Justification = "Test Suites do not need XML Documentation.")]
    public class DiskSpaceStatusTests
    {
        [Fact]
        public void Details_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal("Status Details", status.Details);
        }

        [Fact]
        public void FreeSpace_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(50, status.FreeSpace);
        }

        [Fact]
        public void FreeSpacePercent_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(40, status.FreeSpacePercent);
        }

        [Fact]
        public void InstanceId_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(1, status.InstanceId);
        }

        [Fact]
        public void Plugin_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.IsAssignableFrom<IHealthCheckPlugin>(status.Plugin);
        }

        [Fact]
        public void Size_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(10000, status.Size);
        }

        [Fact]
        public void Status_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(CheckResult.Success, status.Status);
        }

        [Fact]
        public void StatusCode_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(101, status.StatusCode);
        }

        [Fact]
        public void Summary_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal("Status Summary", status.Summary);
        }

        [Fact]
        public void Timestamp_Should_ReturnCorrectValue()
        {
            // Arrange & Act
            var status = CreateHealthStatus();

            // Assert
            Assert.Equal(DateTime.MinValue, status.Timestamp);
        }

        private DiskSpaceStatus CreateHealthStatus()
        {
            var mock = new Mock<IHealthCheckPlugin>();
            _ = mock.Setup(f => f.Name).Returns("UnitTest Plugin");

            return new DiskSpaceStatus()
            {
                Details = "Status Details",
                InstanceId = 1,
                FreeSpace = 50,
                FreeSpacePercent = 40,
                Plugin = mock.Object,
                Size = 10000,
                Status = CheckResult.Success,
                StatusCode = 101,
                Summary = "Status Summary",
                Timestamp = DateTime.MinValue
            };
        }
    }
}
