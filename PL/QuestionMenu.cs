using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using Entities;
namespace PL
{
    class QuestionMenu
    {
        QuestionEntityService service = new QuestionEntityService();
        public void AddQuestion()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, до якого хочете додати питання: ");
                name = Console.ReadLine().Trim();
                string questionName = "";
                Console.WriteLine($"Введіть суть питання, яке хочете додати до тесту {name}: ");
                questionName = Console.ReadLine().Trim();
                if(questionName.Length <= 2)
                {
                    throw new Exception("Мінімальна довжина питання - 3 символи");
                }
                Question question = new Question(questionName);
                service.AddQuestion(name, question);

                Console.WriteLine($"Питання було успішно додано до тесту {name}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveQuestion()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, з якого бажаєте видалити питання: ");
                name = Console.ReadLine().Trim();

                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, яке бажаєте видалити: ");
                questionNumber = Int32.Parse(Console.ReadLine());
                service.RemoveData(name, questionNumber);
                Console.WriteLine($"Питання було успішно видалено з тесту {name}");
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

        public void UpdateQuestion()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, в якому бажаєте оновити питання: ");
                name = Console.ReadLine().Trim();

                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, яке бажаєте змінити: ");
                questionNumber = Int32.Parse(Console.ReadLine());
                string questionName = "";
                Console.WriteLine($"Введіть нове ім'я цього питання: ");
                questionName = Console.ReadLine().Trim();
                if (questionName.Length <= 2)
                {
                    throw new Exception("Мінімальна довжина питання - 3 символи");
                }
                service.UpdateData(name, questionNumber, questionName);
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

        public void GetAllQuestions()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, перелік питань якого ви бажаєте подивитись: ");
                name = Console.ReadLine().Trim();

                Question[] questions = service.getAllQuestionsForTest(name);

                foreach (var item in questions)
                {
                    QuestionOutput(item);

                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetQuestion()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, в якому ви бажаєте знайти питання: ");
                name = Console.ReadLine().Trim();
                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, яке бажаєте знайти: ");
                questionNumber = Int32.Parse(Console.ReadLine());
                Question question = service.GetOneQuestionForTest(name, questionNumber);
                QuestionOutput(question);
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
                AnswerOutput(item, i + 1);
                i++;
            }
            Console.WriteLine("----------------------------------");
        }
    }
}
