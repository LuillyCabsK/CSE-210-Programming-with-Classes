#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <ctime>
#include "Entry.h"

using namespace std;  // Para no escribir std:: todo el tiempo

// Función para mostrar el menú principal
void displayMenu() {
    cout << "\n=== MI DIARIO PERSONAL ===" << endl;
    cout << "1. Escribir nueva entrada" << endl;
    cout << "2. Mostrar todas las entradas" << endl;
    cout << "3. Guardar diario en archivo" << endl;
    cout << "4. Cargar diario desde archivo" << endl;
    cout << "5. Salir" << endl;
    cout << "Selecciona una opción (1-5): ";
}

// Función para obtener la fecha actual como string
string getCurrentDate() {
    time_t now = time(0);
    tm* timeinfo = localtime(&now);
    
    // Formato: DD/MM/AAAA
    char buffer[11];
    strftime(buffer, sizeof(buffer), "%d/%m/%Y", timeinfo);
    return string(buffer);
}

// Función para obtener un prompt aleatorio
string getRandomPrompt() {
    // Lista de prompts/preguntas para el diario
    vector<string> prompts = {
        "¿Quién fue la persona más interesante con la que interactué hoy?",
        "¿Cuál fue la mejor parte de mi día?",
        "¿Cómo vi la mano del Señor en mi vida hoy?",
        "¿Cuál fue la emoción más fuerte que sentí hoy?",
        "Si tuviera algo que pudiera hacer hoy, ¿qué sería?",
        "¿Qué aprendí hoy?",
        "¿Por qué estoy agradecido hoy?"
    };
    
    // Generar número aleatorio entre 0 y tamaño de la lista - 1
    int randomIndex = rand() % prompts.size();
    return prompts[randomIndex];
}

// Función para escribir nueva entrada
void writeNewEntry(vector<Entry>& journal) {
    cout << "\n--- NUEVA ENTRADA ---" << endl;
    
    // Obtener fecha actual y prompt aleatorio
    string currentDate = getCurrentDate();
    string randomPrompt = getRandomPrompt();
    
    // Mostrar el prompt al usuario
    cout << randomPrompt << endl;
    cout << "Escribe tu respuesta: ";
    
    // Leer la respuesta del usuario
    string userResponse;
    cin.ignore(); // Limpiar el buffer del teclado
    getline(cin, userResponse);
    
    // Crear nueva entrada y agregarla al diario
    Entry newEntry(currentDate, randomPrompt, userResponse);
    journal.push_back(newEntry);
    
    cout << "¡Entrada guardada exitosamente!" << endl;
}

// Función para mostrar todas las entradas
void displayJournal(const vector<Entry>& journal) {
    if (journal.empty()) {
        cout << "\nEl diario está vacío. ¡Escribe tu primera entrada!" << endl;
        return;
    }
    
    cout << "\n--- TODAS LAS ENTRADAS DEL DIARIO ---" << endl;
    for (int i = 0; i < journal.size(); i++) {
        cout << "\nEntrada #" << (i + 1) << ":" << endl;
        journal[i].displayEntry();
    }
}

// Función para guardar el diario en un archivo
void saveJournalToFile(const vector<Entry>& journal) {
    if (journal.empty()) {
        cout << "\nNo hay entradas para guardar." << endl;
        return;
    }
    
    cout << "\nIngresa el nombre del archivo para guardar (ej: midiario.txt): ";
    string filename;
    cin >> filename;
    
    // Abrir archivo para escribir
    ofstream outputFile(filename);
    
    if (outputFile.is_open()) {
        // Escribir cada entrada en el archivo separado por |
        for (const Entry& entry : journal) {
            outputFile << entry.getDate() << "|" 
                      << entry.getPrompt() << "|" 
                      << entry.getResponse() << endl;
        }
        outputFile.close();
        cout << "Diario guardado en '" << filename << "' exitosamente!" << endl;
    } else {
        cout << "Error: No se pudo crear el archivo." << endl;
    }
}

// Función para cargar diario desde archivo
void loadJournalFromFile(vector<Entry>& journal) {
    cout << "\nIngresa el nombre del archivo para cargar (ej: midiario.txt): ";
    string filename;
    cin >> filename;
    
    // Abrir archivo para leer
    ifstream inputFile(filename);
    
    if (inputFile.is_open()) {
        // Limpiar el diario actual antes de cargar
        journal.clear();
        
        string line;
        while (getline(inputFile, line)) {
            // Separar la línea usando | como delimitador
            size_t pos1 = line.find('|');
            size_t pos2 = line.find('|', pos1 + 1);
            
            if (pos1 != string::npos && pos2 != string::npos) {
                string date = line.substr(0, pos1);
                string prompt = line.substr(pos1 + 1, pos2 - pos1 - 1);
                string response = line.substr(pos2 + 1);
                
                // Crear nueva entrada y agregarla al diario
                Entry newEntry(date, prompt, response);
                journal.push_back(newEntry);
            }
        }
        inputFile.close();
        cout << "Diario cargado desde '" << filename << "' exitosamente!" << endl;
    } else {
        cout << "Error: No se pudo abrir el archivo." << endl;
    }
}

// Función principal
int main() {
    vector<Entry> journal;  // Vector para almacenar todas las entradas
    int choice;
    
    // Semilla para números aleatorios
    srand(time(0));
    
    cout << "¡Bienvenido a tu Diario Personal!" << endl;
    
    do {
        displayMenu();
        cin >> choice;
        
        switch (choice) {
            case 1:
                writeNewEntry(journal);
                break;
            case 2:
                displayJournal(journal);
                break;
            case 3:
                saveJournalToFile(journal);
                break;
            case 4:
                loadJournalFromFile(journal);
                break;
            case 5:
                cout << "\n¡Gracias por usar tu diario! Hasta pronto." << endl;
                break;
            default:
                cout << "\nOpción inválida. Intenta de nuevo." << endl;
        }
        
    } while (choice != 5);
    
    return 0;
}