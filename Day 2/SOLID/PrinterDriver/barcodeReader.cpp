#ifndef BARCODEREADER_H
#define BARCODEREADER_H

#include "InputDevice.cpp"

class BarcodeReader : public InputDevice {
private:
    int currentScan = 0;

public:
    std::string readPage() override {
        currentScan++;
        return "Scanned Barcode " + std::to_string(currentScan);
    }

    bool isEndOfFile() override {
        return currentScan >= 3; // Example: Stop after 3 barcodes
    }
};

#endif // BARCODEREADER_H
