using InsuranceProject.Service;
using InsuranceProject.Services;

namespace InsuranceProject.DTO
{
    public class CountData
    {
        private IAgentService _agentService;
        private IEmployeeService _employeeService;
        private ICustomerService _customerService;
        private IInsuranceTypeService _insuranceTypeService;
        private IInsuranceSchemeService _insuranceSchemeService;
        private ILocationService _locationService;
        //Count For Admin Dashboard
        public int CountAgents { get; set; } = 0;
        public int CountEmployees { get; set; } = 0;
        public int CountCustomers { get; set; } = 0;
        public int CountInsuranceTypes { get; set;} = 0;
        public int CountInsuranceSchemes { get; set; } = 0;
        public int CountLocations { get; set;} = 0;
        //Count For Agent Dashboard
        //public int CountAgentCustomer { get; set;}
        //public int CountCustomerInsuranceAccount { get; set;}
        //public int AgentTotalCommision { get; set;}

        public CountData(IAgentService agentService,IEmployeeService employeeService,ICustomerService customerService,
            IInsuranceTypeService insuranceTypeService, ILocationService locationService, IInsuranceSchemeService insuranceSchemeService)
        {
            _agentService = agentService;
            _employeeService = employeeService;
            _customerService = customerService;
            _insuranceTypeService = insuranceTypeService;
            _locationService = locationService;
            _insuranceSchemeService = insuranceSchemeService;
            SetCount();
        }
        public void SetCount()
        {
            CountAgents = _agentService.GetAll().Count();
            CountEmployees = _employeeService.GetAll().Count();
            CountCustomers = _customerService.GetAll().Count();
            CountInsuranceTypes = _insuranceTypeService.GetAll().Count();
            CountInsuranceSchemes = _insuranceSchemeService.GetAll().Count();
            CountLocations = _locationService.GetAll().Count();
        }
        
    }
}
