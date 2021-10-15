#include <iostream>
#include <vector>
#include <string>
using namespace std;

void splitString(vector<string>& vect, string str);

int main()
{
	string line; // Initial line of words
	vector<string> listOfWords; // Vector which is going to contain words as it's elements
	string longestOdd; // Longest word in odd position

	cout << "Enter a line: ";
	getline(cin, line);

	splitString(listOfWords, line);

	if (listOfWords.size() == 0)
	{
		cout << "New line is: " << line << "\nThe longest word in odd position is " << line;
	}
	else
	{
		for (int i = listOfWords.size() - 1; i >= 0; i--)
		{
			if (i % 2 == 1)
			{
				listOfWords.erase(listOfWords.begin() + i);
			}
		}

		longestOdd = listOfWords[0];
		for (int i = 0; i < listOfWords.size(); i++)
		{
			if (listOfWords[i].size() > longestOdd.size())
			{
				longestOdd = listOfWords[i];
			}
		}

		cout << "New line is: ";
		for (int i = 0; i < listOfWords.size(); i++)
		{
			cout << " " << listOfWords[i];
		}
		cout << "\nThe longest word in odd position is " << longestOdd;
	}
}

// Function which splits a line into single words and adds them to a vector
void splitString(vector<string>& vect, string str) 
{
	string buffer = ""; // Buffer which will contain words until they are added to vector
	for (int i = 0; i < str.size(); i++)
	{
		if (str[i] != ' ')
		{
			buffer.push_back(str[i]);
		}
		else
		{
			vect.push_back(buffer);
			buffer = "";
		}
	}
	vect.push_back(buffer);
}