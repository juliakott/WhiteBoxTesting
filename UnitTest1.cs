using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.BinaryFlag;

namespace WhiteBoxTesting
{
    [TestClass]
    public class BinaryFlagTest
    {
        [TestMethod]
        public void Test_ConstructorMinLengthException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1));
        }

        [TestMethod]
        public void Test_ConstructorMinLengthSuccess()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(2));
        }

        [TestMethod]
        public void Test_ConstructorMaxLengthException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868705));
        }

        [TestMethod]
        public void Test_ConstructorLengthBetween33And64()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(57));
        }

        [TestMethod]
        public void Test_ConstructorMaxLengthSuccess()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(17179868704));
        }

        [TestMethod]
        public void Test_FlagsNotNull()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
            MultipleBinaryFlag mbf3 = new MultipleBinaryFlag(8, true);
            Assert.IsNotNull(mbf1);
            Assert.IsNotNull(mbf2);
            Assert.IsNotNull(mbf3);
        }

        [TestMethod]
        public void Test_GetType()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
            MultipleBinaryFlag mbf3 = new MultipleBinaryFlag(8, true);
            Assert.AreEqual(mbf1.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
            Assert.AreEqual(mbf2.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
            Assert.AreEqual(mbf3.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
        }

        [TestMethod]
        public void Test_TwoFlagsNotEqualSameState()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, true);
            Assert.AreNotEqual(mbf1, mbf2);
        }

        [TestMethod]
        public void Test_TwoFlagsNotEqualDifferentState()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
            Assert.AreNotEqual(mbf1, mbf2);
        }

        [TestMethod]
        public void Test_TwoFlagsDifferentState()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8, true);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
            Assert.AreNotEqual(mbf1.GetFlag(), mbf2.GetFlag());
            Assert.IsTrue(mbf1.GetFlag());
            Assert.IsFalse(mbf2.GetFlag());
        }

        [TestMethod]
        public void Test_TwoFlagsSameState()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, true);
            Assert.AreEqual(mbf1.GetFlag(), mbf2.GetFlag());
        }

        [TestMethod]
        public void Test_SetFlagOnePosition()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8, false);
            Assert.IsFalse(mbf.GetFlag());
            mbf.SetFlag(3);
            Assert.IsFalse(mbf.GetFlag());
        }

        [TestMethod]
        public void Test_SetFlagAllPositions()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8, false);
            Assert.IsFalse(mbf.GetFlag());
            for (ulong i = 0; i < 8; i++)
            {
                mbf.SetFlag(i);
            }
            Assert.IsTrue(mbf.GetFlag());
        }

        [TestMethod]
        public void Test_SetFlagOutOfRange()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mbf.SetFlag(9));
        }

        [TestMethod]
        public void Test_ResetFlagOnePosition()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            Assert.IsTrue(mbf.GetFlag());
            mbf.ResetFlag(3);
            Assert.IsFalse(mbf.GetFlag());
        }

        [TestMethod]
        public void Test_ResetFlagAllPositions()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            Assert.IsTrue(mbf.GetFlag());
            for (ulong i = 0; i < 8; i++)
            {
                mbf.ResetFlag(i);
            }
            Assert.IsFalse(mbf.GetFlag());
        }

        [TestMethod]
        public void Test_ResetFlagOutOfRange()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mbf.ResetFlag(9));
        }

        [TestMethod]
        public void Test_ToString()
        {
            MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
            MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
            Assert.AreEqual("TTTTTTTT", mbf1.ToString());
            Assert.AreEqual("FFFFFFFF", mbf2.ToString());
        }

        [TestMethod]
        public void Test_ToStringAfterSetFlagOnePosition()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8, false);
            Assert.AreEqual(mbf.ToString(), "FFFFFFFF");
            mbf.SetFlag(3);
            Assert.AreEqual(mbf.ToString(), "FFFTFFFF");
        }

        [TestMethod]
        public void Test_ToStringAfterSetFlagAllPositions()
        {

            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8, false);
            Assert.AreEqual("FFFFFFFF", mbf.ToString());
            for (ulong i = 0; i < 8; i++)
            {
                mbf.SetFlag(i);
            }
            Assert.AreEqual("TTTTTTTT", mbf.ToString());
        }

        [TestMethod]
        public void Test_ToStringAfterResetFlagOnePosition()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            mbf.ResetFlag(3);
            Assert.AreEqual("TTTFTTTT", mbf.ToString());
        }

        [TestMethod]
        public void Test_ToStringAfterResetFlagAllPositions()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            for (ulong i = 0; i < 8; i++)
            {
                mbf.ResetFlag(i);
            }
            Assert.AreEqual("FFFFFFFF", mbf.ToString());
        }

        [TestMethod]
        public void Test_DisposeNotNull()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(8);
            mbf.Dispose();
            Assert.IsNotNull(mbf);
            mbf.Dispose();
            Assert.IsTrue(mbf.GetFlag());
            mbf.ResetFlag(1);
            Assert.AreEqual("TFTTTTTT", mbf.ToString());
        }
  
    }
}
