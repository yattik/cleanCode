#ifndef SCANNERINPUTDEVICE_H
#define SCANNERINPUTDEVICE_H

#include "InputDevice.cpp"

class ScannerInputDevice : public InputDevice {
private:
    int currentPage = 0;

public:
    std::string readPage() override {
        currentPage++;
        return "Scanned Page " + std::to_string(currentPage);
    }

    bool isEndOfFile() override {
        return currentPage >= 2; // Example: Stop after 2 pages
    }
};

#endif // SCANNERINPUTDEVICE_H
