using NUnit.Framework;

namespace tests.reference.nunit
{
    namespace TestsInDerivedClasses
    {
        public class ConcreteBaseClassWithNoAttribute
        {
            // No marker, but gets run as part of derived class
            [Test]
            public void IsThisATest()
            {
                Assert.AreEqual(1, 1);
            }
        }

        [TestFixture]
        public class ConcreteBaseClassWithAttribute
        {
            // Gets a marker and is listed under this class and derived class
            [Test]
            public void MyTestMethod()
            {
                Assert.IsTrue(1 == 1);
            }
        }

        public class DerivedClassWithNoAttribute : ConcreteBaseClassWithAttribute
        {
            // Also includes "ConcreteBaseClassWithAttribute.QuickTestMethod"
            // Gets a marker and a test
            [Test]
            public void AnotherTest()
            {
                Assert.IsTrue(2 == 2);
            }
        }

        [TestFixture]
        public class DerivedClassWithAttribute : ConcreteBaseClassWithNoAttribute
        {
            // Also includes "ConcreteBaseClassWithNoAttribute.IsThisATest"
            // Gets a marker and a test
            [Test]
            public void ShouldBeTwoTestsInThisClass()
            {
                Assert.IsTrue(2 == 2);
            }
        }

        [TestFixture]
        public abstract class AbstractBaseClassWithAttribute
        {
            // No maker
            [Test]
            public void HereIsATest()
            {
                Assert.IsTrue(2 == 2);
            }
        }

        public class NoAttributeDerivedFromAbstractClass : AbstractBaseClassWithAttribute
        {
            // Includes "AbstractBaseClassWithAttribute.HereIsATest"

            [Test]
            public void LocalTest()
            {
                Assert.IsTrue(2 == 2);
            }
        }

        public abstract class AbstractBaseClassWithNoAttribute
        {
            // No marker
            [Test]
            public void AnotherTest()
            {
                Assert.IsTrue(2 == 2);
            }
        }

        [TestFixture]
        public class AttributeDerivedFromAbstractClassWithNoAttribute : AbstractBaseClassWithNoAttribute
        {
            // Includes "AbstractBaseClassWithNoAttribute.AnotherTest"
            // Gets a marker
            [Test]
            public void JustAnotherTest()
            {
                Assert.AreEqual(2, 2);
            }
        }
    }
}