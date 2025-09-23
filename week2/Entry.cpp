#include "Entry.h"
#include <iostream>

// Constructor vacío - como una hoja en blanco
Entry::Entry() {
    date = "";
    prompt = "";
    response = "";
}

// Constructor con datos - como llenar la hoja
Entry::Entry(std::string entryDate, std::string entryPrompt, std::string entryResponse) {
    date = entryDate;
    prompt = entryPrompt;
    response = entryResponse;
}

// Obtener la fecha
std::string Entry::getDate() {
    return date;
}

// Obtener la pregunta
std::string Entry::getPrompt() {
    return prompt;
}

// Obtener la respuesta
std::string Entry::getResponse() {
    return response;
}

// Mostrar la entrada bonita
void Entry::displayEntry() {
    std::cout << "\n=== " << date << " ===" << std::endl;
    std::cout << "Pregunta: " << prompt << std::endl;
    std::cout << "Respuesta: " << response << std::endl;
    std::cout << "=====================" << std::endl;
}