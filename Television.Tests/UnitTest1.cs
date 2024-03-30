namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice tvDevice;
        private const string Brand = "LG";
        private const double Price = 1999.99;
        private const int ScreenWidth = 60;
        private const int ScreenHeigth = 20;
        [SetUp]
        public void Setup()
        {
            tvDevice = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeigth);
        }

        [Test]
        public void Ctor_InitializesObject_PropertiesAreCorrect()
        {
            Assert.That(tvDevice, Is.Not.Null);
            Assert.AreEqual(Brand, tvDevice.Brand);
            Assert.AreEqual(Price, tvDevice.Price);
            Assert.AreEqual(ScreenWidth, tvDevice.ScreenWidth);
            Assert.AreEqual(ScreenHeigth, tvDevice.ScreenHeigth);
            Assert.AreEqual(0, tvDevice.CurrentChannel);
            Assert.AreEqual(13, tvDevice.Volume);
            Assert.AreEqual(false, tvDevice.IsMuted);
        }

        [Test]
        public void ToString_ReturnsCorrectString()
        {
            string expected = $"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeigth}, Price {Price}$";
            string actual = tvDevice.ToString();
            Assert.AreEqual(@expected, actual);
        }

        [Test]
        public void SwitchOn_SwitchesTvOn()
        {
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            string actual = tvDevice.SwitchOn();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChangeChannel_SetsTheCorrectChannel()
        {
            int expectedChannel = 7;
            int actual = tvDevice.ChangeChannel(expectedChannel);
            Assert.AreEqual(expectedChannel, actual);
        }

        [Test]
        public void ChangeChannel_InvalidChannel_ThrowsArgumentException()
        {
            int expectedChannel = -5;
            Assert.Throws<ArgumentException>(() => tvDevice.ChangeChannel(expectedChannel));
        }

        [Test]
        public void Mute_TogglesTheMute()
        {
            tvDevice.MuteDevice();
            Assert.AreEqual(true, tvDevice.IsMuted);
            tvDevice.MuteDevice();
            Assert.AreEqual(false, tvDevice.IsMuted);
        }

        [Test]
        public void VolumeUp_PositiveValue_SetsCorrectVolume()
        {
            int units = 7;
            string expected = "Volume: 20";
            string actual = tvDevice.VolumeChange("UP", units);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VolumeUp_NegativeValue_SetsCorrectVolume()
        {
            int units = -10;
            string expected = "Volume: 23";
            string actual = tvDevice.VolumeChange("UP", units);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VolumeUp_VolumeAboveMaxValue_SetsVolumeTo100()
        {
            int units = 95;
            string expected = "Volume: 100";
            string actual = tvDevice.VolumeChange("UP", units);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VolumeDown_VolumeBelowMinValue_SetsVolumeTo0()
        {
            int units = 95;
            string expected = "Volume: 0";
            string actual = tvDevice.VolumeChange("DOWN", units);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VolumeDown_PositiveValue_SetsCorrectVolume()
        {
            int units = 7;
            string expected = "Volume: 6";
            string actual = tvDevice.VolumeChange("DOWN", units);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void VolumeDown_NegativeValue_SetsCorrectVolume()
        {
            int units = -5;
            string expected = "Volume: 8";
            string actual = tvDevice.VolumeChange("DOWN", units);
            Assert.AreEqual(expected, actual);
        }
    }
}