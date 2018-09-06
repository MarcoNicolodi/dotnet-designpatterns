using System;
using System.Collections.Generic;

namespace Visitor
{
    public interface Person
    {
        void Accept(IVisitor visitor);
    }

    public class Employee : Person
    {
        public double Earning { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BoardMember : Person
    {
        public double BoardMeetingAttendanceRate { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CFO : Person
    {
        public double CompanyStockValueGrowth { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        void Visit(Employee person);
        void Visit(CFO person);
        void Visit(BoardMember person);
    }


    public class AnualBonusVisitor : IVisitor
    {
        public void Visit(CFO cfo)
        {
            var bonus = cfo.CompanyStockValueGrowth * 1000;
            Console.WriteLine($"{cfo.GetType().Name} anual bonus is {bonus}");
        }

        public void Visit(Employee employee)
        {
            var bonus = employee.Earning * 1;
            Console.WriteLine($"{employee.GetType().Name} anual bonus is {bonus}");
        }

        public void Visit(BoardMember boardMember)
        {
            var bonus = boardMember.BoardMeetingAttendanceRate * 10000;
            Console.WriteLine($"{boardMember.GetType().Name} anual bonus is {bonus}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Person>()
            {
                new CFO(){ CompanyStockValueGrowth = 15 },
                new BoardMember { BoardMeetingAttendanceRate = 99.8 },
                new Employee { Earning = 15000 }
            };

            var anualBonusVisitor = new AnualBonusVisitor();

            employees.ForEach(e => e.Accept(anualBonusVisitor));

            Console.WriteLine("Hello World!");
        }
    }
}
