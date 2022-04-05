﻿using Models;

namespace BL;

public interface ISLBL
{
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Employee> GetAllEmployees();
    List<Product> GetAllProducts();
    List<InventoryItem> GetAllInventoryItems();
    List<OrderItem> GetAllOrderItems();
    List<Order> GetAllOrders();
    void AddCustomer(Customer customerToAdd);
    void PurchaseItem(int customerId, int storeId, int inventoryItemId, int quantity);
}
