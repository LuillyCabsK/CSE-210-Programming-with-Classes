#ifndef ENTRY_H
#define ENTRY_H

#include <string>

class Entry {
private:
    std::string date;        // Entry date
    std::string prompt;      // dayli question prompt
    std::string response;    // user's response

public:
    // Constructors (like "molds" to create entries) for Entry objects
    Entry();
    Entry(std::string entryDate, std::string entryPrompt, std::string entryResponse);
    
    //  Methods for obtaining data from the entry
    std::string getDate();
    std::string getPrompt();
    std::string getResponse();
    
    // Method to display the input nicely
    void displayEntry();
};

#endif