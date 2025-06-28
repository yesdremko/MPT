using NUnit.Framework;
using FacadePattern;

namespace FacadePatternTest
{
    [TestFixture]
    public class FacadeTests
    {
        private SubsystemA _a;
        private SubsystemB _b;
        private Facade _facade;

        [SetUp]
        public void Setup()
        {
            _a = new SubsystemA();
            _b = new SubsystemB();
            _facade = new Facade(_a, _b);
        }

        [Test]
        public void SubsystemA_Operation1_ReturnsExpected()
        {
            Assert.That(_a.Operation1(), Is.EqualTo("SubsystemA: готовий до роботи."));
        }

        [Test]
        public void SubsystemA_OperationN_ReturnsExpected()
        {
            Assert.That(_a.OperationN(), Is.EqualTo("SubsystemA: виконує свою частину."));
        }

        [Test]
        public void SubsystemB_Operation1_ReturnsExpected()
        {
            Assert.That(_b.Operation1(), Is.EqualTo("SubsystemB: підготовлений."));
        }

        [Test]
        public void SubsystemB_OperationZ_ReturnsExpected()
        {
            Assert.That(_b.OperationZ(), Is.EqualTo("SubsystemB: виконує іншу частину."));
        }

        [Test]
        public void Facade_PerformComplexOperation_ContainsAllSteps()
        {
            var output = _facade.PerformComplexOperation();
            StringAssert.Contains("Фасад ініціалізує підсистеми:", output);
            StringAssert.Contains("SubsystemA: готовий до роботи.", output);
            StringAssert.Contains("SubsystemB: підготовлений.", output);
            StringAssert.Contains("Фасад віддає команди підсистемам:", output);
            StringAssert.Contains("SubsystemA: виконує свою частину.", output);
            StringAssert.Contains("SubsystemB: виконує іншу частину.", output);
        }
    }
}
