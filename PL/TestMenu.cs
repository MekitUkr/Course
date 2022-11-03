using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using Entities;
using TestLibrary;

namespace PL
{
    public class TestMenu
    {
        TestEntityService service = new TestEntityService();
        StartTest Start = new StartTest();
        public void AddTest()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту: ");
                name = Console.ReadLine().Trim();
                if (name.Length <= 2)
                {
                    throw new Exception("Некоректне ім'я тесту, мінімальна довжина назви тесту - 3 символи");
                }
                if (!service.isUnique(name))
                {
                    throw new Exception("Тест с таким ім'ям вже існує, введіть інше ім'я");
                }
                Test test = new Test(name);
                service.AddTest(test);
                Console.WriteLine($"Тест {name} було успішно додано до БД");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveTest()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, який бажаєте видалити: ");
                name = Console.ReadLine().Trim();
                service.RemoveTest(name);
                Console.WriteLine($"Тест {name} було успішно видалено з БД");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTestName()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, який бажаєте оновити: ");
                name = Console.ReadLine().Trim();
                if (service.isUnique(name))
                {
                    throw new Exception("Тесту с таким ім'ям не існує, введіть інше ім'я");
                }
                string newName = "";
                Console.WriteLine("Введіть нове ім'я тесту: ");
                newName = Console.ReadLine().Trim();
                if (newName.Length <= 2)
                {
                    throw new Exception("Некоректне ім'я тесту, мінімальна довжина назви тесту - 3 символи");
                }
                if (!service.isUnique(newName))
                {
                    throw new Exception("Тест с таким ім'ям вже існує, введіть інше ім'я");
                }
                service.UpdateData(name, newName);
                Console.WriteLine($"Ім'я тесту {name} було успішно змінено на {newName}");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateTimeForQuestion()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, для якого бажаєте оновити час на 1 питання: ");
                name = Console.ReadLine().Trim();
                if (service.isUnique(name))
                {
                    throw new Exception("Тесту с таким ім'ям не існує, введіть інше ім'я");
                }
                int newTime = 0;
                Console.WriteLine("Введіть час на 1 питання для цього тесту:");
                newTime = Int32.Parse(Console.ReadLine());
                if (newTime <= 0)
                {
                    throw new Exception("Некоректний час на 1 питання");
                }
                service.UpdateTimeForOneQuestion(name,newTime);
                Console.WriteLine("Час на одне питання був успішно змінений");
            }
            catch (FormatException ex)
            {
                throw new Exception("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateNumberOfQuestions()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, для якого бажаєте змінити к-сть питань: ");
                name = Console.ReadLine().Trim();
                if (service.isUnique(name))
                {
                    throw new Exception("Тесту с таким ім'ям не існує, введіть інше ім'я");
                }
                int newQuestionNumber = 0;
                Console.WriteLine("Введіть нову к-сть питань лля цього тесту для цього тесту:");
                newQuestionNumber = Int32.Parse(Console.ReadLine());
                if (newQuestionNumber <= 0)
                {
                    throw new Exception("Некоректна к-сть питань");
                }
                service.UpdateQuestionsNumber(name, newQuestionNumber);
                Console.WriteLine($"К-сть питань для тесту {name} була успішно змінена на {newQuestionNumber}");
            }
            catch (FormatException ex)
            {
                throw new Exception("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetTest()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, який бажаєте знайти: ");
                name = Console.ReadLine().Trim();
                Test test = service.GetOneTest(name);
                TestOutput(test);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void GetAllTest()
        {
            Console.WriteLine("Перелік всіх тестів у БД: ");
            Test[] tests = service.GetAllTests();
            Console.WriteLine($"Всього тестів: {tests.Length}");
            foreach (var item in tests)
            {
                TestOutput(item);
            }
        }

        public void StartTheTest()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, який бажаєте пройти: ");
                name = Console.ReadLine().Trim();
                Start.TestName = name;
                Start.Start();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private void AnswerOutput(Answer answer, int i)
        {
            string isRight = answer.IsRight ? "+" : "";
            Console.WriteLine($"Відповідь {i}: {answer.MyAnswer} {isRight}");
        }

        private void QuestionOutput(Question question)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Суть питання: {question.QuestionName}");
            Console.WriteLine($"К-сть відповідей на це питання: {question.countLength()}");
            int i = 0;
            Console.WriteLine("Cписок відповідей на це питання: ");
            foreach (var item in question.Answers)
            {
                AnswerOutput(item, i+1);
                i++;
            }
            Console.WriteLine("----------------------------------");
        }

        private void TestOutput(Test test)
        {
            Console.WriteLine($"Тест: {test.Name}");
            Console.WriteLine($"К-сть питань в тесті: {test.countLength()}");
            Console.WriteLine($"Час на одне питання в тесті: {test.TimeForOneQuestion}");
            Console.WriteLine($"Відсоток правильних відповідей під час останнього проходження тесту: {test.PercentageOfCorrectAnswers}");
            Console.WriteLine("Питання тесту: ");
            Console.WriteLine($"Всього питань:  {test.countLength()}");
            foreach (var item in test.Questions)
            {
                QuestionOutput(item);
            }
            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine();
        }

        public void TestStatisicOutput()
        {
            TestUtils[] utils = Start.Statistic;
            if(utils.Length == 0)
            {
                Console.WriteLine("Сатистика порожня. Ви не пройшло ще жодного тесту.");
            }
            foreach(var item in utils)
            {
                Console.WriteLine($"Сатистика по тесту {item.TestName}:");
                Console.WriteLine($"Тест було пройдено {item.Percentages.Length} разів");
                Console.WriteLine($"Статистика проходжень: ");
                int i = 1;
                foreach(var percent in item.Percentages)
                {
                    Console.WriteLine($"Проходження номер {i}: ");
                    Console.WriteLine($"{percent}% правильних відповідей");
                    i++;
                }
                Console.WriteLine();
            }
        }

    }

    public class StartTest 
    {
        TestEntityService service;
        AnswerEntityService AnswerService;
        TestStatistic statistic;
        private string testName;
        public string TestName { get=>testName; set=>testName=value; }
        public TestUtils[] Statistic { get=>statistic.Utils; private set { } }
        public StartTest()
        {
            service = new TestEntityService();
            AnswerService = new AnswerEntityService();
            statistic = new TestStatistic();
        }
        private void AnswerOutput(Answer answer, int i)
        {
            Console.WriteLine($"Відповідь {i}: {answer.MyAnswer}");
        }
        private void QuestionOutput(Question question)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Суть питання: {question.QuestionName}");
            Console.WriteLine($"К-сть відповідей на це питання: {question.countLength()}");
            int i = 0;
            Console.WriteLine("Cписок відповідей на це питання: ");
            foreach (var item in question.Answers)
            {
                AnswerOutput(item, i + 1);
                i++;
            }
            Console.WriteLine("----------------------------------");
        }
        public void Start()
        {
            try
            {
                int correctAnswers = 0;
                Test test = service.GetOneTest(testName);
                Question[] questions = test.Questions;
                int i = 1;//счетчик для вопросов
                foreach (var item in questions)
                {
                    QuestionOutput(item);
                    Console.WriteLine("Виберіть номер відповіді на поточне питання, яку вважаєте правильною: ");
                    string current = Console.ReadLine().Trim();
                    if (current == "Quit")
                    {
                        return;
                    }
                    else
                    {
                        int numberOfChoosenAnswer = Int32.Parse(current);
                        bool isRight = AnswerService.CheckAnswer(testName, i, numberOfChoosenAnswer);
                        if (isRight)
                        {
                            correctAnswers++;
                        }
                    }
                    i++;
                }
                int percentage = service.countPercentages(testName, correctAnswers);
                TestUtils utils = new TestUtils(testName, percentage);
                statistic.AddToTheStatistic(utils);
            }
            catch (FormatException ex)
            {
                throw new Exception("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
