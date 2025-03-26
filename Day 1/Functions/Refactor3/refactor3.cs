public class EmployeeDatabase
{
    private readonly IDbConnection _db;

    public EmployeeDatabase(IDbConnection dbConnection)
    {
        _db = dbConnection;
    }

    public Employee GetEmployee(int id)
    {
        return _db.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employees WHERE Id = @Id",
            new { Id = id });
    }

    public void SaveEmployee(Employee emp)
    {
        _db.Execute(
            "UPDATE Employees SET Name = @Name WHERE Id = @Id",
            new { emp.Name, emp.Id });
    }

    public void DeleteEmployee(int id)
    {
        _db.Execute(
            "DELETE FROM Employees WHERE Id = @Id",
            new { Id = id });
    }
}

public class EmployeeService
{
    private readonly EmployeeDatabase _employeeDatabase;

    public EmployeeService(EmployeeDatabase employeeDatabase)
    {
        _employeeDatabase = employeeDatabase;
    }

    public Employee GetEmployee(int id)
    {
        if (id < 50)
        {
            throw new InvalidDataException("Employee ID starts from 50. IDs 1 to 49 are reserved for promoters, investors, etc. Data cannot be shared in HRMS due to security issues.");
        }

        return _employeeDatabase.GetEmployee(id);
    }

    public void UpdateEmployee(Employee emp)
    {
        if (emp.Name.Length > 150)
        {
            throw new InvalidDataException("Name too long.");
        }

        _employeeDatabase.SaveEmployee(emp);
    }

    public void RemoveEmployee(int id)
    {
        if (id == 1)
        {
            throw new InvalidDataException("Chairman cannot be removed.");
        }

        _employeeDatabase.DeleteEmployee(id);
    }
}
