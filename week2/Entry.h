#ifndef ENTRY_H
#define ENTRY_H

#include <string>

class Entry {
private:
    std::string date;        // Fecha de la entrada
    std::string prompt;      // Pregunta del día
    std::string response;    // Respuesta del usuario

public:
    // Constructores (como "moldes" para crear entradas)
    Entry();
    Entry(std::string entryDate, std::string entryPrompt, std::string entryResponse);
    
    // Métodos para obtener datos
    std::string getDate();
    std::string getPrompt();
    std::string getResponse();
    
    // Método para mostrar la entrada
    void displayEntry();
};

#endif