﻿using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class Customer
{
    public int CustomerID { get; set; }
    public string? CostumerName { get; set; }
    public string? ContactName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
}

class ApiClient
{

    static WebProxy proxy = new WebProxy("http://localhost:5137", BypassOnLocal: false);
    static HttpClientHandler httpClientHandler = new HttpClientHandler
    {
        Proxy = proxy,
        UseProxy = true,
    };

    static HttpClient client = new HttpClient();

    public ApiClient(HttpClient httpClient)
    {
        client = httpClient;
    }

    public async Task<List<Customer>?> GetCustomersAsync()
    {
        var response = await client.GetAsync("api/customers");
        response.EnsureSuccessStatusCode();
        var customers = await response.Content.ReadFromJsonAsync<List<Customer>>();
        return customers;
    }

    static async Task<Customer?> GetCustomerAsync(int id)
    {
        var response = await client.GetAsync($"api/customers/{id}");
        response.EnsureSuccessStatusCode();
        var customer = await response.Content.ReadFromJsonAsync<Customer>();
        return customer;
    }

    static async Task<int> CreateCustomerAsync(Customer customer)
    {
        var response = await client.PostAsJsonAsync("api/customers", customer);
        response.EnsureSuccessStatusCode();
        return response.Content.ReadFromJsonAsync<Customer>().Id;
    }

    static async Task UpdateCustomerAsync(int id, Customer customer)
    {
        var response = await client.PutAsJsonAsync($"api/customers/{id}", customer);
        response.EnsureSuccessStatusCode();
    }

    static async Task<HttpStatusCode> DeleteCustomerAsync(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"api/customers/{id}");
        return response.StatusCode;
    }

    static void ShowCustomer(Customer customer)
    {
        Console.WriteLine($"Name: {customer.CostumerName}\nName for contact: {customer.ContactName}" +
                          $"\nLocation: {customer.City}, {customer.Country}");
    }


    static async Task RunAsync()
    {
        
        client.BaseAddress = new Uri("http://localhost:5137/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
          
            Customer customer = new Customer
            {
                CostumerName = "йцук",
                ContactName = "ывамп",
                Country = "ывап",
                City = "ывпаып"
            };

            var id = await CreateCustomerAsync(customer);
            Console.WriteLine($"Created at {id}");

            customer = await GetCustomerAsync(id);
            ShowCustomer(customer);

            Console.WriteLine("Updating price...");
            customer.CostumerName = "фывафыа";
            await UpdateCustomerAsync(id, customer);

            customer = await GetCustomerAsync(id);
            ShowCustomer(customer);

            var statusCode = await DeleteCustomerAsync(customer.CustomerID);
            Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }


    static void Main()
    {
        RunAsync().GetAwaiter().GetResult();
    }
}