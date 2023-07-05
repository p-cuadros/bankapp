using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Bank.Domain.Tests.Steps
{
    [Binding]
    public sealed class AccountStepsTests
    {
        private readonly ScenarioContext _scenarioContext;
        private Account _cuenta { get; set; }
        private string _error { get; set; }
        private bool _es_error { get; set; } = false;
        
        public AccountStepsTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("la nueva cuenta numero (.*)")]
        public void DadoUnaNuevaCuenta(string numeroCuenta)
        {
            try
            {
                _cuenta = Account.Open(numeroCuenta);
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }            
        }

        // [Given("con saldo (.*)")]
        // public void YConSaldo(decimal monto)
        // {
        //     CuandoYoDeposito(monto);
        // }

        [Given("con saldo (.*)")]
        [When("deposito (.*)")]
        public void CuandoYoDeposito(decimal monto)
        {
            try
            {
                _cuenta.Deposit(monto);
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }
        }

        [When("retiro (.*)")]
        public void CuandoYoRetiro(decimal monto)
        {
            try
            {
                _cuenta.Withdraw(monto);
                //_resultado = _cuenta.Saldo;
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }
        }

        [Then("el saldo nuevo deberia ser (.*)")]
        public void EntoncesElResultadoDeberiaSer(decimal resultado)
        {
            Assert.AreEqual(_cuenta.Balance, resultado);
        }        

        [Then("deberia ser error")]
        public void EntoncesDeberiaMostrarseError()
        {
            Assert.IsTrue(_es_error);
        }

        [Then("deberia mostrarse el error: (.*)")]
        public void EntoncesDeberiaMostrarseError(string error)
        {
            Assert.AreEqual(_error, error);
        }
    }
}