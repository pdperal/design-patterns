using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IMultiFunctionalDevice : IScanner, IPrinter
    {

    }

    public class MultiFunctionMachine : IMultiFunctionalDevice
    {
        private IPrinter Printer;
        private IScanner Scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            Printer = printer ?? throw new ArgumentNullException(nameof(printer));
            Scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
        }

        // Decorator pattern
        public void Print(Document d)
        {
            Printer.Print(d);
        }

        public void Scan(Document d)
        {
            Scanner.Scan(d);
        }
    }

    public class PhotCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class MultiFunctiononalPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class OldFashionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            //
        }

        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }

    public class ISP
    {

        public static void MainISP()
        {

        }
    }
}
