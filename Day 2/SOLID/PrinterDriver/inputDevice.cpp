#ifndef INPUTDEVICE_H
#define INPUTDEVICE_H

#include <string>

class InputDevice {
public:
    virtual ~InputDevice() = default;
    virtual std::string readPage() = 0;
    virtual bool isEndOfFile() = 0;
};

#endif // INPUTDEVICE_H
