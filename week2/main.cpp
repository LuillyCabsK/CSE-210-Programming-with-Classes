#include <iostream>      // to use std::cout, std::cin, std::endl
#include <vector> // to use std::vector
#include <string> // to use std::string 
#include <fstream> // work with files
#include <cstdlib>   // For rand() and srand()
#include <ctime>     // obtain current time for seeding random
#include "Entry.h"    // include the Entry class definition

using namespace std;  // Para no escribir std:: todo el tiempo

// Function to display main menu
void displayMenu() {
    cout << "\n=== MY PERSONAL 'Diary' JOURNAL ===" << endl;
    cout << "1. Write new entry" << endl;
    cout << "2. Display all entries" << endl;
    cout << "3. Save journal to file" << endl;
    cout << "4. Load journal from file" << endl;
    cout << "5. Exit" << endl;
    cout << "Select an option (1-5): ";
}

// funtion to get current date as string
string getCurrentDate() {
    time_t now = time(0);
    tm* timeinfo = localtime(&now);
    
    // Format date: Day/Month/Year
    char buffer[11];
    strftime(buffer, sizeof(buffer), "%d/%m/%Y", timeinfo);
    return string(buffer);
}

// function to get a random prompt from predefined list
string getRandomPrompt() {
    // list of prompts/questions 
    vector<string> prompts = {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today?",
        "What am I grateful for today?"
    };
    
    // Generate random number between 0 and list size - 1
    int randomIndex = rand() % prompts.size();
    return prompts[randomIndex];
}

// new entry function
void writeNewEntry(vector<Entry>& journal) {
    cout << "\n--- NEW ENTRY ---" << endl;
    
    // obtain current date and random prompt
    string currentDate = getCurrentDate();
    string randomPrompt = getRandomPrompt();
    
    // show prompt to user
    cout << randomPrompt << endl;
    cout << "Write your response: ";
    
    // read user response
    string userResponse;
    cin.ignore(); // clean the input buffer
    getline(cin, userResponse);
    
    // create new Entry object and add to journal
    Entry newEntry(currentDate, randomPrompt, userResponse);
    journal.push_back(newEntry);
    
    cout << "Entry saved successfully!" << endl;
}

// display all entries function
void displayJournal(const vector<Entry>& journal) {
    if (journal.empty()) {
        cout << "\nThe journal is empty. Write your first entry!" << endl;
        return;
    }
    
    cout << "\n--- ALL JOURNAL ENTRIES ---" << endl;
    for (int i = 0; i < journal.size(); i++) {
        cout << "\nEntrada #" << (i + 1) << ":" << endl;
        journal[i].displayEntry();
    }
}

// save journal to file function
void saveJournalToFile(const vector<Entry>& journal) {
    if (journal.empty()) {
        cout << "\nNo entries to save." << endl;
        return;
    }
    
    cout << "\nEnter filename to save (ex: myjournal.txt): or as you prefer to name it! ";
    string filename; 
    cin >> filename; 
    
    // open file to write
    ofstream outputFile(filename);
    
    if (outputFile.is_open()) {
        // write each entry in the file as | delimited
        for (const Entry& entry : journal) {
            outputFile << entry.getDate() << "|" 
                      << entry.getPrompt() << "|" 
                      << entry.getResponse() << endl;
        }
        outputFile.close();
        cout << "Journal saved to '" << filename << "' successfully!" << endl;
    } else {
        cout << "Error: Could not create the file." << endl;
    }
}

// function to load journal from file
void loadJournalFromFile(vector<Entry>& journal) {
    cout << "\nIngresa el nombre del archivo para cargar (ej: midiario.txt): ";
    string filename;
    cin >> filename;
    
    // open file to read
    ifstream inputFile(filename);
    
    if (inputFile.is_open()) {
        // clear current journal
        journal.clear();
        
        string line;
        while (getline(inputFile, line)) {
            // write each entry in the file as | delimited
            size_t pos1 = line.find('|');
            size_t pos2 = line.find('|', pos1 + 1);
            
            if (pos1 != string::npos && pos2 != string::npos) {
                string date = line.substr(0, pos1);
                string prompt = line.substr(pos1 + 1, pos2 - pos1 - 1);
                string response = line.substr(pos2 + 1);
                
                // create Entry object and add to journal
                Entry newEntry(date, prompt, response);
                journal.push_back(newEntry);
            }
        }
        inputFile.close();
        cout << "Journal loaded from  '" << filename << "' successfully!" << endl;
    } else {
        cout << "Error: Could not open the file" << endl;
    }
}

// main function
int main() {
    vector<Entry> journal;  // vector to store journal entries
    int choice;
    
    // random number generator
    srand(time(0));
    
    cout << "Welcome to your Personal Journal!" << endl;
    
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
                cout << "\nThanks for using this app to save your memories! see you tomorrow" << endl;
                break;
            default:
                cout << "\nInvalid option. Please try again." << endl;
        }
        
    } while (choice != 5);
    
    return 0;
}