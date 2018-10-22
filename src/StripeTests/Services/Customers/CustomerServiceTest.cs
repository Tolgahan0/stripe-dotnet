namespace StripeTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class CustomerServiceTest : BaseStripeTest
    {
        private const string CustomerId = "cus_123";

        private CustomerService service;
        private CustomerCreateOptions createOptions;
        private CustomerUpdateOptions updateOptions;
        private CustomerListOptions listOptions;

        public CustomerServiceTest()
        {
            this.service = new CustomerService();

            this.createOptions = new CustomerCreateOptions()
            {
                Email = "example@example.com",
                SourceToken = "tok_123",
            };

            this.updateOptions = new CustomerUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new CustomerListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var customer = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers");
            Assert.NotNull(customer);
            Assert.Equal("customer", customer.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var customer = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers");
            Assert.NotNull(customer);
            Assert.Equal("customer", customer.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(CustomerId);
            this.AssertRequest(HttpMethod.Delete, "/v1/customers/cus_123");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(CustomerId);
            this.AssertRequest(HttpMethod.Delete, "/v1/customers/cus_123");
            Assert.NotNull(deleted);
        }

        [Fact]
        public void Get()
        {
            var customer = this.service.Get(CustomerId);
            this.AssertRequest(HttpMethod.Get, "/v1/customers/cus_123");
            Assert.NotNull(customer);
            Assert.Equal("customer", customer.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var customer = await this.service.GetAsync(CustomerId);
            this.AssertRequest(HttpMethod.Get, "/v1/customers/cus_123");
            Assert.NotNull(customer);
            Assert.Equal("customer", customer.Object);
        }

        [Fact]
        public void List()
        {
            var customers = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/customers");
            Assert.NotNull(customers);
            Assert.Equal("list", customers.Object);
            Assert.Single(customers.Data);
            Assert.Equal("customer", customers.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var customers = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/customers");
            Assert.NotNull(customers);
            Assert.Equal("list", customers.Object);
            Assert.Single(customers.Data);
            Assert.Equal("customer", customers.Data[0].Object);
        }

        [Fact]
        public void Update()
        {
            var customer = this.service.Update(CustomerId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers/cus_123");
            Assert.NotNull(customer);
            Assert.Equal("customer", customer.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var customer = await this.service.UpdateAsync(CustomerId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers/cus_123");
            Assert.NotNull(customer);
            Assert.Equal("customer", customer.Object);
        }
    }
}