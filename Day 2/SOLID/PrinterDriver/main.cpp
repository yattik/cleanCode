#include <iostream>
#include "PrinterDriver.cpp"
#include "FileInputDevice.cpp"
#include "ScannerInputDevice.cpp"

int main() {
    try {
        // Example: Using File as an input device
        FileInputDevice fileInput("document.txt");
        PrinterDriver filePrinterDriver(&fileInput);
        filePrinterDriver.print();

        // Example: Using Scanner as an input device
        ScannerInputDevice scannerInput;
        PrinterDriver scannerPrinterDriver(&scannerInput);
        scannerPrinterDriver.print();

    } catch (const std::exception& e) {
        std::cerr << "Error: " << e.what() << std::endl;
    }

    return 0;
}
