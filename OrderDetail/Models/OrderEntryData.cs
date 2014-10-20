using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrderDetail.Models
{
    public class OrderEntryData
    {
    }

    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Column("CustId")]
        public int custId{get; set;}
        public string custNo { get; set; }
        public string custFirstName { get; set; }
        public string custLastName { get; set; }
        public string custStreet { get; set; }
        public string custCity { get; set; }
        public string custState { get; set; }
        public string custZip { get; set; }
        public decimal custBal { get; set; }
    }

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId       {get; set;}
        public string EmpNo     {get; set;}
        public string EmpFirstName {get; set;}
        public string EmpLastName {get; set;}
        public string EmpPhone     {get; set;}
        public string SupEmpNo     {get; set;}
        public decimal EmpCommRate  {get; set;}
        public string EmpEmail    {get; set;}
    }

    [Table("OrderTbl")]
    public class OrderTbl
    {
        [Key]
        public int OrdId { get; set;}
        public string OrdNo {get; set;}
        public DateTime  OrdDate {get; set;}
        public string CustNo {get; set;}
        public string EmpNo {get; set;}
        public string OrdName {get; set;}
        public string OrdStreet {get; set;}
        public string OrdCity {get; set;}
        public string OrdState {get; set;}
        public string OrdZip {get; set;}
    }

    [Table("OrdLine")]
    public class OrdLine
    {
        [Key]
        public int OrdLineId {get; set;}
        public string OrdNo {get; set;}
        public string ProdNo {get; set;}
        public int Qty {get; set;}
    }

    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProdId {get; set;}
        public string ProdNo {get; set;}
        public string ProdName {get; set;}
        public string ProdMfg {get; set;}
        public int ProdQOH {get; set;}
        public decimal ProdPrice  {get; set;}
        public DateTime? ProdNextShipDate {get; set;}
    }

    public class OrderEntryDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<OrderTbl> orders { get; set; }
        public DbSet<OrdLine> orderLines { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }

    public class OrderDetail
    {
        [Key]
        public int? OrdLineId { get; set; }
        public string ProdNo { get; set; }
        public string ProdName { get; set; }
        public int Qty { get; set; }
        public decimal ProdPrice { get; set; }
    }

    public class OrderDetails
    {
        public List<OrderDetail> orderDetails { get; set; }
    }
}