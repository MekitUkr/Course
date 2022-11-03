using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BLL;
namespace PL
{
    class AnswerMenu
    {
        AnswerEntityService service = new AnswerEntityService();
        public void AddAnswer()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, до питання якого хочете додати відповідь: ");
                name = Console.ReadLine().Trim();
                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, до якого бажаєте додати відповідь: ");
                questionNumber = Int32.Parse(Console.ReadLine());

                string answerName = "";
                Console.WriteLine($"Введіть текст відповіді на запитання: ");
                answerName = Console.ReadLine();
                string isRight = "";
                bool correct = false;
                Console.WriteLine($"Введіть + або - в залежності від того, чи правильна буде ця відповідь: ");
                isRight = Console.ReadLine().Trim();
                switch (isRight) 
                {
                    case "+":
                        correct = true;
                        break;
                    case "-":
                        correct = false;
                        break;
                    default:
                        throw new Exception($"Ви повинні ввести \"+\" або \"-\".Ви ввели - {isRight} ");
                        break;
                }
                Answer answer = new Answer(answerName, correct);
                service.AddAnswer(name, questionNumber, answer);
                Console.WriteLine($"Відповідь на питання під номером {questionNumber} була успішно додана до тесту {name}");
            }
            catch (FormatException ex)
            {
                throw new Exception("Некоректний ввід даних, наступного разу введіть, будь ласка, число!");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveAnswer()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, до питання якого хочете видалити відповідь: ");
                name = Console.ReadLine().Trim();
                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, в якому ви бажаєте видалити відповідь: ");
                questionNumber = Int32.Parse(Console.ReadLine());
                int answerNumber = 0;
                Console.WriteLine("Введіть номер відпвіді, яку бажаєте видалити: ");
                answerNumber = Int32.Parse(Console.ReadLine());
                service.RemoveData(name, questionNumber, answerNumber);
                Console.WriteLine($"Відповідь на питання під номером {questionNumber} була успішно видалена з тесту {name}");
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

        public void UpdateAnswer()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, в якому бажаєте оновити відповідь на питання: ");
                name = Console.ReadLine().Trim();

                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, в якому бажаєте змінити відповідь: ");
                questionNumber = Int32.Parse(Console.ReadLine());
                int answerNumber = 0;
                Console.WriteLine("Введіть номер відповіді, яку бажаєте змінити: ");
                answerNumber = Int32.Parse(Console.ReadLine());
                string answerName = "";
                Console.WriteLine($"Введіть новий текст відповіді на запитання: ");
                answerName = Console.ReadLine();
                string isRight = "";
                bool correct = false;
                Console.WriteLine($"Введіть + або - в залежності від того, чи правильна буде ця відповідь: ");
                isRight = Console.ReadLine().Trim();
                switch (isRight)
                {
                    case "+":
                        correct = true;
                        break;
                    case "-":
                        correct = false;
                        break;
                    default:
                        throw new Exception($"Ви повинні ввести \"+\" або \"-\".Ви ввели - {isRight} ");
                        break;
                }
                service.UpdateData(name, questionNumber, answerNumber, answerName, correct);
                Console.WriteLine($"Відповідь на питання тесту {name} під номером {questionNumber} було успішно змінено");
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

        public void GetAllAnswers()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, в якому бажаєте переглянути відповіді на питання: ");
                name = Console.ReadLine().Trim();

                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, в якому бажаєте переглянути відповіді: ");
                questionNumber = Int32.Parse(Console.ReadLine());

                Answer[] answers = service.GetAllAnswersForQuestion(name, questionNumber);
                int i = 0;
                foreach (var item in answers)
                {
                    AnswerOutput(item,i+1);
                    i++;
                }
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

        public void GetAnswer()
        {
            try
            {
                string name = "";
                Console.WriteLine("Введіть ім'я тесту, в якому бажаєте знайти відповідь на питання: ");
                name = Console.ReadLine().Trim();

                int questionNumber = 0;
                Console.WriteLine("Введіть номер питання, в якому бажаєте знайти відповідь: ");
                questionNumber = Int32.Parse(Console.ReadLine());
                int answerNumber = 0;
                Console.WriteLine("Введіть номер відповіді, яку бажаєте знайти: ");
                answerNumber = Int32.Parse(Console.ReadLine());
                Answer answer = service.GetOneAnswerForQuestion(name, questionNumber, answerNumber);
                AnswerOutput(answer, answerNumber);
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
    }
}

