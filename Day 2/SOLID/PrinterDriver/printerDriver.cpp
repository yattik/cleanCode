#ifndef PRINTERDRIVER_H
#define PRINTERDRIVER_H

#include "InputDevice.cpp"
#include <iostream>

class PrinterDriver {
private:
    InputDevice* inputDevice;

public:
    explicit PrinterDriver(InputDevice* inputDev) : inputDevice(inputDev) {}

    void print() {
        while (!inputDevice->isEndOfFile()) {
            std::cout << "Printing: " << inputDevice->readPage() << std::endl;
        }
    }
};

#endif // PRINTERDRIVER_H
