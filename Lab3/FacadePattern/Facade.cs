using System.Text;

namespace FacadePattern
{
    public class Facade
    {
        private readonly SubsystemA _subA;
        private readonly SubsystemB _subB;

        public Facade(SubsystemA subA, SubsystemB subB)
        {
            _subA = subA;
            _subB = subB;
        }

        public string PerformComplexOperation()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Фасад ініціалізує підсистеми:");
            sb.AppendLine(_subA.Operation1());
            sb.AppendLine(_subB.Operation1());
            sb.AppendLine("Фасад віддає команди підсистемам:");
            sb.AppendLine(_subA.OperationN());
            sb.AppendLine(_subB.OperationZ());

            return sb.ToString().TrimEnd();
        }
    }
}
