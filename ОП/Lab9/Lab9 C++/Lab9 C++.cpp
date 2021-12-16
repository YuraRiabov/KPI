#include <iostream>
#include <string>
using namespace std;

string* SplitString(string line, int& size);
void DeleteEven(string* array, int& size);
void DeleteElement(string* array, int& size, int index);
string FindLongestWord(string* array, int size);
string JoinToString(string* array, int size);

int main()
{
	string line;
	string newLine;
	string* listOfWords;
	string longestWord;
	int size = 0;

	cout << "Enter string: ";
	getline(cin, line);

	listOfWords = SplitString(line, size);
	DeleteEven(listOfWords, size);
	longestWord = FindLongestWord(listOfWords, size);
	newLine = JoinToString(listOfWords, size);

	cout << "New string: " << newLine;
	cout << "\nLongest word in odd position: " << longestWord << "\n";

	delete[] listOfWords;
	system("pause");
}

string* SplitString(string line, int& size)
{
	int maxWordCount = line.size() / 2 + 1;
	string* listOfWords = new string[maxWordCount];
	string buffer = "";
	int arrayIndex = 0;

	for (int i = 0; i < line.size(); i++)
	{
		if (line[i] == ' ')
		{
			listOfWords[arrayIndex] = buffer;
			buffer = "";
			arrayIndex++;
		}
		else
		{
			buffer += line[i];
		}
	}
	listOfWords[arrayIndex] = buffer;

	size = arrayIndex + 1;

	return listOfWords;
}

void DeleteEven(string* array, int& size)
{
	for (int i = size - 1; i > 0; i--)
	{
		if (i % 2 == 1)
		{
			DeleteElement(array, size, i);
		}
	}
}

void DeleteElement(string* array, int& size, int index)
{
	for (int i = index + 1; i < size; i++)
	{
		array[i - 1] = array[i];
	}
	size--;
}

string FindLongestWord(string* array, int size)
{
	string longestWord = array[0];
	for (int i = 1; i < size; i++)
	{
		if (array[i].size() > longestWord.size())
		{
			longestWord = array[i];
		}
	}
	return longestWord;
}

string JoinToString(string* array, int size)
{
	string line = "";
	for (int i = 0; i < size - 1; i++)
	{
		line += array[i] + " ";
	}
	line += array[size - 1];
	return line;
}