#include "Entry.h"
#include <iostream>

// Default constructor - creates empty entry (like a blank sheet)
Entry::Entry() {
    date = "";
    prompt = "";
    response = "";
}

// Parameterized constructor - creates entry with data provided
Entry::Entry(std::string entryDate, std::string entryPrompt, std::string entryResponse) {
    date = entryDate;
    prompt = entryPrompt;
    response = entryResponse;
}

// date
std::string Entry::getDate() {
    return date;
}

// possible question prompt
std::string Entry::getPrompt() {
    return prompt;
}

// get a answer from user
std::string Entry::getResponse() {
    return response;
}

// Display formatted entry to the console
void Entry::displayEntry() {
    std::cout << "\n=== " << date << " ===" << std::endl;
    std::cout << "Prompt: " << prompt << std::endl;
    std::cout << "Response: " << response << std::endl;
    std::cout << "=====================" << std::endl;
}