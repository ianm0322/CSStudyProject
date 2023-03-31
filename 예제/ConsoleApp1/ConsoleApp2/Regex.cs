using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

class RegexTest
{
    public const string PHONE_NUMBERS_PATTERN = "^01[0-9]-?[0-9]{4}-?[0-9]{4}$";
    public const string USER_NAME_PATTERN = "^[가-힣]{2,4}$";

    void Main(string[] args)
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        while (true)
        {
            Console.WriteLine("사용자 : 전화번호 입력");
            Console.Write("입력 => ");
            var input = Console.ReadLine();
            if (input == "끝")
                break;
            try
            {
                var split = input.Split(" ");

                bool isCorrectName = Regex.IsMatch(split[0], USER_NAME_PATTERN);
                bool isCorrectPhone = Regex.IsMatch(split[1], PHONE_NUMBERS_PATTERN);

                if (!isCorrectName && !isCorrectPhone)
                {
                    Console.WriteLine("사용자 이름과 전화번호의 형식이 맞지 않습니다.");
                    continue;
                }
                else if (!isCorrectPhone)
                {
                    Console.WriteLine("전화번호의 형식이 맞지 않습니다.");
                    continue;
                }
                else if (!isCorrectName)
                {
                    Console.WriteLine("사용자 이름의 형식이 맞지 않습니다.");
                    continue;
                }

                // 사용자 이름만 입력했고, 그 이름이 이미 존재한다면, phoneBook에서 삭제.
                else if (phoneBook.ContainsKey(split[0]) && split.Length == 1)
                {
                    Console.WriteLine($"{split[0]}을 삭제하였습니다.");
                    if (phoneBook.Remove(split[0]))
                    {
                        Console.WriteLine("삭제 중 오류 발생!");
                        throw new Exception();
                    }
                }
                // 중복 이름이 있으면 오류
                else if (!phoneBook.TryAdd(split[0], split[1]))
                {
                    Console.WriteLine("동명의 사용자가 존재합니다.");
                    continue;
                }
            }
            catch
            {
                Console.WriteLine("잘못된 값이 입력되었습니다.");
                continue;
            }

        }

        foreach (var key in phoneBook.Keys)
        {
            string value;
            if (phoneBook.TryGetValue(key, out value))
            {
                Console.WriteLine($"{key} : [{value}]");
            }
            else
            {
                Console.WriteLine("전화번호부 출력 중 오류 발생!");
                throw new Exception();
            }
        }

        List<string> keys = new(phoneBook.Keys);
        for (int i = 0; i < keys.Count; i++)
        {
            phoneBook.Remove(keys[i]);
        }
    }
}