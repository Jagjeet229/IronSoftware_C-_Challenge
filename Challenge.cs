
using System;
using System.Collections.Generic;
using System.Text;


public class OldPhone
{
    public static void Main(string[] args)
    {        
        Console.WriteLine (OldPhonePad("222 2 22#"));
        Console.WriteLine (OldPhonePad("33#"));
        Console.WriteLine (OldPhonePad("227*#"));
        Console.WriteLine (OldPhonePad("4433555 555666##"));
        Console.WriteLine (OldPhonePad("8 88777444666*664#"));
        
    }
    
  public static string OldPhonePad(string input ){
    Dictionary<char, string[]> wordDictionary = new Dictionary<char, string[]>();
    wordDictionary.Add('2', new string[] {"A","B","C"});
    wordDictionary.Add('3', new string[] {"D","E","F"});
    wordDictionary.Add('4', new string[] {"G","H","I"});
    wordDictionary.Add('5', new string[] {"J","K","L"});
    wordDictionary.Add('6', new string[] {"M","N","O"});
    wordDictionary.Add('7', new string[] {"P","Q","R","S"});
    wordDictionary.Add('8', new string[] {"T","U","V"});
    wordDictionary.Add('9', new string[] {"W","X","Y","Z"});
    

    StringBuilder answer = new StringBuilder();
    
    int count =0;
    char lastChar = '\0';
    for(int i=0;i<input.Length;i++){
       
      if(lastChar=='\0'){
          lastChar = input[i];
          count++;
      } 
       
      else if(input[i] == lastChar){
          count = count+1;
      }
      else if(input[i] == '*'){
          lastChar = '\0';
          count=0;
      }
      else if(input[i] == ' ' || input[i] == '0'){
          answer.Append(wordDictionary[lastChar][count-1]);
          lastChar = input[i+1];
          count=0;
      }
      else if(input[i] == '#'){
          answer.Append(wordDictionary[input[i-1]][count-1]);
          return answer.ToString();
      }
      else if(input[i]!= lastChar){
          answer.Append(wordDictionary[input[i-1]][count-1]);
          lastChar = input[i];
          count=1;
         
      }
    }
    return answer.ToString();
  }
}