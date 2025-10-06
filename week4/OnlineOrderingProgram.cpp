#include <iostream>
#include <iomanip>
#include <string>
#include <vector>
using namespace std;

class Address {
private:
    string street, city, state, country;

public:
    Address(string s, string c, string st, string co)
        : street(s), city(c), state(st), country(co) {}

    bool IsInUSA() const {
        string upper = country;
        for (auto &ch : upper) ch = toupper(ch);
        return (upper == "USA" || upper == "UNITED STATES");
    }

    string GetFullAddress() const {
        return street + "\n" + city + ", " + state + "\n" + country;
    }
};

class Customer {
private:
    string name;
    Address address;

public:
    Customer(string n, Address a) : name(n), address(a) {}

    bool LivesInUSA() const { return address.IsInUSA(); }

    string GetName() const { return name; }

    Address GetAddress() const { return address; }
};

class Product {
private:
    string name, productId;
    double price;
    int quantity;

public:
    Product(string n, string id, double p, int q)
        : name(n), productId(id), price(p), quantity(q) {}

    double GetTotalCost() const { return price * quantity; }

    string GetName() const { return name; }

    string GetProductId() const { return productId; }
};

class Order {
private:
    Customer customer;
    vector<Product> products;

public:
    Order(Customer c) : customer(c) {}

    void AddProduct(const Product &p) { products.push_back(p); }

    double GetTotalPrice() const {
        double total = 0;
        for (auto &p : products) total += p.GetTotalCost();
        total += (customer.LivesInUSA() ? 5.0 : 35.0); // Shipping cost
        return total;
    }

    string GetPackingLabel() const {
        string label = "📦 Packing Label:\n";
        for (auto &p : products)
            label += " - " + p.GetName() + " (ID: " + p.GetProductId() + ")\n";
        return label;
    }

    string GetShippingLabel() const {
        return "🚚 Shipping Label:\n" + customer.GetName() + "\n" + customer.GetAddress().GetFullAddress();
    }

    void PrintSummary() const {
        cout << GetPackingLabel() << endl;
        cout << GetShippingLabel() << endl;
        cout << fixed << setprecision(2);
        cout << "💲 Total: $" << GetTotalPrice() << endl;
        cout << "-----------------------------\n";
    }
};

int main() {
    Address addr1("123 Main St", "Provo", "UT", "USA");
    Address addr2("Calle 45 #7n 85", "Popayán", "Cauca", "Colombia");

    Customer c1("Ana Moskera", addr1);
    Customer c2("Carlos Gómez", addr2);

    Order o1(c1);
    o1.AddProduct(Product("Laptop HP", "customHD8000", 800, 1));
    o1.AddProduct(Product("Mouse Logitech", "G203", 25, 2));

    Order o2(c2);
    o2.AddProduct(Product("Poleron", "C300", 30, 3));
    o2.AddProduct(Product("Pants", "P400", 45, 1));

    o1.PrintSummary();
    o2.PrintSummary();

    return 0;
}
