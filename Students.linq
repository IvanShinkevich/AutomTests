<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Hello!");
	GreetUserAndGetStudents();
}

private void GreetUserAndGetStudents(){
	Console.WriteLine("Hello! Please, enter the amount of students:");
	var input = Console.ReadLine();
	try{
		int studentsAmo = Convert.ToInt32(input);
		var students = CreateStudents(studentsAmo);
		ShowAllAverages(students);
	}
	catch(Exception ex){
		Console.WriteLine($"Error!{ex.Message}");
	}
}

private void ShowAllAverages(Student[] students){
ShowAllStudents(students);
		ShowEveryStudentAverage(students);
		ShowAllStudentsAverage(students);
		FindParticularStudentInfo(students);
}

private void FindParticularStudentInfo(Student[] students){
Console.WriteLine("Enter the name of student you want to find");
var studentName = Console.ReadLine();
ShowParticularStudentAverage(students, studentName);
}

private void ShowAllStudents(Student[] students){
foreach(var student in students){
		student.ShowStudent();
		}
}

private void ShowEveryStudentAverage(Student[] students){
foreach(var student in students){
		student.ShowStudentAverageMark();
		}
}

private void ShowParticularStudentAverage(Student[] students, string name){
	try{var st = students.First(s => s.GetName() == name);
	Console.WriteLine($"Name: {st.GetName()}. Average: {st.GetAverageStudentMark()}");
	}
	catch(Exception ex){
	Console.WriteLine($"Error! {ex.Message} Please, enter other student name: ");
	FindParticularStudentInfo(students);
	}
}

private void ShowAllStudentsAverage(Student[] students){
	Console.WriteLine($"All students average: {GetAllStudentsAverage(students)}");
}

private float GetAllStudentsAverage(Student[] students){
	int marksSum=0;
	int marksAmo=0;
	foreach(var student in students){
		 marksSum+= student.GetMarks().Sum();
		 marksAmo+= student.GetMarks().Count();
		}
		return marksSum/marksAmo;
}

private Student[] CreateStudents(int studentsAmo){
	Student[] st = new Student[studentsAmo];
	for(int i=0;i<studentsAmo;i++){
		string name = GetName();
		int[] marks = GetMarks();
		if(marks.Count() == 0){
		i--;
		Console.WriteLine("Incorrect input. One more time, please");
		} else{
		st[i] = new Student(name, marks);
		}
	}
	return st;
}

private string GetName(){
	 Console.WriteLine("Enter student name please: ");
	 string input = Console.ReadLine();
	 return input;
}

private int[] GetMarks(){
	Console.WriteLine("Enter marks, please(separate with the space them, please: ");
	string input = Console.ReadLine();
	int[] marks={};
	try{
	marks = input.Split(' ').Select(int.Parse).ToArray();
	foreach(var mark in marks){
		if(mark<=0 || mark>10){
			throw new ArgumentException();
		}
	}
} 
  catch(Exception ex){
		Console.WriteLine($"Error!{ex.Message} Please, try again.");
		return GetMarks();
	}
	return marks;
}

public class Student{
	string name {get;set;}
	int[] marks {get; set;}
	public Student(string studentName, int[] marks){
		this.name = studentName;
		this.marks = marks;
	}
private string ShowMarksAsString(){
	var str = "";
	foreach(var mark in marks){
		str+=mark+" ";
	}
	return str;
}

public int[] GetMarks(){
	return marks;
}

public string GetName(){
	return name;
}

public float GetAverageStudentMark(){
	return this.marks.Sum()/marks.Count();
}

public void ShowStudentAverageMark(){
	Console.WriteLine($"Name: {name}. Marks: {ShowMarksAsString()}. Average mark: {GetAverageStudentMark()}.");
}

public void ShowStudent(){
	Console.WriteLine($"Name: {name}; Marks: {ShowMarksAsString()}");
	}
}