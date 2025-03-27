#ifndef FILEINPUTDEVICE_H
#define FILEINPUTDEVICE_H

#include "InputDevice.cpp"
#include <fstream>
#include <string>

class FileInputDevice : public InputDevice {
private:
    std::ifstream file;

public:
    explicit FileInputDevice(const std::string& fileName) {

    std::string readPage() override {
        std::string line;
        std::getline(file, line); // Read one line as a page
        return line;
    }

    bool isEndOfFile() override {
        return file.eof();
    }
};

#endif // FILEINPUTDEVICE_H
