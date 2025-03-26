public void ProcessOrder(Order order)
{
    if (order == null)
        throw new ArgumentNullException(nameof(order));

    if (!OrderIsValid(order))
        throw new InvalidOperationException("Invalid order");

    decimal total = CalculateTotal(order);
    total = ApplyDiscount(order, total);
    SaveToDB(order, total);
    SendConfirmationEmail(order, total);
}

private bool OrderIsValid(Order order)
{
    return order.Items.Count > 0;
}

private decimal CalculateTotal(Order order)
{
    return order.Items.Sum(item => 
        item.Price * item.Quantity * (1 + (item.IsTaxable ? 0.1m : 0)));
}

private decimal ApplyDiscount(Order order, decimal total)
{
    if (order.Customer.IsPremium)
    {
        return total * 0.9m; // 10% discount
    }
    return total;
}

private void SaveToDB(Order order, decimal total)
{
    using (var db = new AppDbContext())
    {
        order.Total = total;
        db.Orders.Add(order);
        db.SaveChanges();
    }
}

private void SendConfirmationEmail(Order order, decimal total)
{
    var emailService = new EmailService();
    emailService.Send(order.Customer.Email, "Order Confirmed", $"Total: ${total:F2}");
}
