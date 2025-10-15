<<<<<<< HEAD
#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Comment {
private:
    string author;
    string text;

public:
    Comment(string a, string t) : author(a), text(t) {}

    string GetAuthor() const { return author; }
    string GetText() const { return text; }
};

class Video {
private:
    string title;
    string author;
    int duration; // segundos
    vector<Comment> comments;

public:
    Video(string t, string a, int d) : title(t), author(a), duration(d) {}

    void AddComment(const Comment &c) {
        comments.push_back(c);
    }

    int GetCommentCount() const {
        return static_cast<int>(comments.size());
    }

    void DisplayVideoInfo() const {
        cout << "-----------------------------------------" << endl;
        cout << "🎬 Título: " << title << endl;
        cout << "👤 Autor: " << author << endl;
        cout << "⏱️ Duración: " << duration / 60 << " min " << duration % 60 << " seg" << endl;
        cout << "💬 Comentarios (" << GetCommentCount() << "):" << endl;

        for (const auto &c : comments) {
            cout << "   • " << c.GetAuthor() << ": " << c.GetText() << endl;
        }
        cout << "-----------------------------------------" << endl;
    }
};

int main() {
    vector<Video> videos;

    Video v1("Aprende C++", "Luilly Cabrera", 300);
    v1.AddComment(Comment("JuanDiego507", "Muy claro el video"));
    v1.AddComment(Comment("Anita", "Excelente explicación"));
    v1.AddComment(Comment("CarlosAgustusSPQR", "Gracias por compartir"));
    videos.push_back(v1);

    Video v2("Receta scout", "Luilly Cabrera", 180);
    v2.AddComment(Comment("Maria_camila_hxrmxsitx", "La haré en casa"));
    v2.AddComment(Comment("JorgeRAZ", "Se ve deliciosa"));
    videos.push_back(v2);

    cout << "📺 Mostrando información de " << videos.size() << " videos:\n" << endl;
    for (const auto &v : videos) {
        v.DisplayVideoInfo();
    }

    return 0;
}
=======
#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Comment {
private:
    string author;
    string text;

public:
    Comment(string a, string t) : author(a), text(t) {}

    string GetAuthor() const { return author; }
    string GetText() const { return text; }
};

class Video {
private:
    string title;
    string author;
    int duration; // segundos
    vector<Comment> comments;

public:
    Video(string t, string a, int d) : title(t), author(a), duration(d) {}

    void AddComment(const Comment &c) {
        comments.push_back(c);
    }

    int GetCommentCount() const {
        return static_cast<int>(comments.size());
    }

    void DisplayVideoInfo() const {
        cout << "-----------------------------------------" << endl;
        cout << "🎬 Título: " << title << endl;
        cout << "👤 Autor: " << author << endl;
        cout << "⏱️ Duración: " << duration / 60 << " min " << duration % 60 << " seg" << endl;
        cout << "💬 Comentarios (" << GetCommentCount() << "):" << endl;

        for (const auto &c : comments) {
            cout << "   • " << c.GetAuthor() << ": " << c.GetText() << endl;
        }
        cout << "-----------------------------------------" << endl;
    }
};

int main() {
    vector<Video> videos;

    Video v1("Aprende C++", "Luilly Cabrera", 300);
    v1.AddComment(Comment("JuanDiego507", "Muy claro el video"));
    v1.AddComment(Comment("Anita", "Excelente explicación"));
    v1.AddComment(Comment("CarlosAgustusSPQR", "Gracias por compartir"));
    videos.push_back(v1);

    Video v2("Receta scout", "Luilly Cabrera", 180);
    v2.AddComment(Comment("Maria_camila_hxrmxsitx", "La haré en casa"));
    v2.AddComment(Comment("JorgeRAZ", "Se ve deliciosa"));
    videos.push_back(v2);

    cout << "📺 Mostrando información de " << videos.size() << " videos:\n" << endl;
    for (const auto &v : videos) {
        v.DisplayVideoInfo();
    }

    return 0;
}
>>>>>>> 00fb2166c54d9fa2754ed2084c44f2583d346700
