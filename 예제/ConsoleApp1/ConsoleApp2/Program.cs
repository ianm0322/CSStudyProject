using System;
using System.Collections.Generic;

class Program
{
    static int Plus(List<int> list)
    {
        int ret = 0;
        for (int i = 0; i < list.Count; i++)
        {
            ret += list[i];
        }
        return ret;
    }

    static int Divide(List<int> list)
    {
        return Plus(list) / list.Count;
    }

    static void Main(string[] args)
    {
        List<int> scores = new List<int>();

        // 입력을 '끝'을 받을 때까지 점수를 입력받는다.
        // 입력예시: "100", "40", "20" etc...
        //           "끝" -> while문 탈출
        //           "asdf", "0 1" ~> 잘못된 구문이라면 다시 반복
        while (true)
        {
            Console.WriteLine("점수를 입력하세요.");
            try
            {
                string input = Console.ReadLine();
                if (input == "끝")
                    break;
                int score = Convert.ToInt32(input);
                scores.Add(score);
            }
            catch
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // 위에서 받은 점수들의 합계와 평균을 출력한다.
        Console.WriteLine($"점수의 합계: {Plus(scores)}");
        Console.WriteLine($"점수의 평균: {Divide(scores)}");


        return;
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.WriteLine("!");

            Console.Write("입력!!!!!!!!!! ");
            int score;
            string name;
            try
            {
                var str = Console.ReadLine();
                if (str == "끝")
                    break;
                var a = str.Split(' ');
                name = a[0];
                score = Convert.ToInt32(a[1]);
                students.Add(new Student() { name = name, score = score });
            }
            catch
            {
                Console.WriteLine("문제가 있다!!! '(학생이름) (점수)' 양식대로 제출하여라!!!!!!!!!!!!");
            }
        }

        Console.WriteLine("잘했따!!!!!!!!!!!!!!!!!!!");
        Console.WriteLine("결과를 알려주겠다ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ!!!!!!!!!!!!!!!!!!!!!!!");
        Console.WriteLine($"합계: {Total(students)}");
        Console.WriteLine($"평균: {Average(students)}");
    }

    static float Average(List<Student> students)
    {
        return Total(students) / students.Count;
    }

    static int Total(List<Student> students)
    {
        int ret = 0;
        for (int i = 0; i < students.Count; i++)
        {
            ret += students[i].Score;
        }
        return ret;
    }
}

class Student
{
    public int score;
    public string name;

    public int Score => score;
}

public class Sandwich
{
    protected Material[] NeedMaterial;
    protected int[] NeedCount;
    public bool IsAbleToMakeSandwich(Material[] _mat, int[] _count)
    {
        for (int i = 0; i < NeedMaterial.Length; i++)
        {
            int curMatIdx = Array.IndexOf(_mat, NeedMaterial[i]);
            // 필요한 재료가 있기는 햐나. 없으면 false 반환.
            if (curMatIdx < 0)
            {
                return false;
            }
            // 재료가 있다면, 수는 충분히 있냐. 없으면 false 반환.
            else if(_count[curMatIdx] < NeedCount[i])
            {
                return false;
            }
        }
        // NeedMaterial의 모든 재료가 _mat에 충분히 있다면, true 반환.
        // 재료가 과한지, 필요 없는 것도 있는지는 확인하지 않음.
        return true;
    }
}

public class Hamburgur : Sandwich
{

}

public class BigMc : Hamburgur
{
    public BigMc()
    {
        
    }
}



public enum Material
{
    SesameBread,
    BeefPatty,
    SpecialSause,
    Lettuce,
    Cheeze,
    Piccle,
    Onion
}