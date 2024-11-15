using System;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        static List<string> tasks = new List<string>(); // Lista para armazenar as tarefas

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true) // Loop para manter o menu ativo
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Gerenciador de Tarefas!");
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Adicionar uma tarefa");
                Console.WriteLine("2. Listar todas as tarefas");
                Console.WriteLine("3. Marcar uma tarefa como concluída");
                Console.WriteLine("4. Remover uma tarefa");
                Console.WriteLine("5. Sair");

                string option = Console.ReadLine() ?? string.Empty;

                switch (option)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ListTasks();
                        break;
                    case "3":
                        MarkTask();
                        break;
                    case "4":
                        RemoveTask();
                        break;
                    case "5":
                        Exit();
                        return; // Sai do loop e do programa
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.WriteLine("Digite o nome da sua tarefa: ");
            string task = Console.ReadLine() ?? string.Empty;
            tasks.Add(task);
            Console.WriteLine("Tarefa adicionada com sucesso!");
            WaitForUserInput(); // Aguarda o usuário digitar outra tarefa
        }

        static void ListTasks()
        {
            Console.WriteLine("Tarefas: ");
            if (tasks.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++) // Itera sobre as tarefas com índice
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}"); // Exibe o índice e a tarefa
                }
            }
            WaitForUserInput();
        }

        static void MarkTask()
        {
            Console.WriteLine("Digite o numero da tarefa que deseja marcar: ");
            int taskNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            if (taskNumber > 0 && taskNumber <= tasks.Count) // Verifica se o número da tarefa é válido
            {
                Console.WriteLine($"Tarefa {taskNumber} marcada como concluída!");
                WaitForUserInput();
            }
            else
            {
                Console.WriteLine("Número inválido!");
                WaitForUserInput();
            }
        }

        static void RemoveTask()
        {
            Console.WriteLine("Digite o numero da tarefa que deseja remover: ");
            int TaskNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            if (TaskNumber > 0 && TaskNumber <= tasks.Count) // Verifica se o número da tarefa é válido
            {
                tasks.RemoveAt(TaskNumber - 1); // Remove a tarefa na posição especificada
                Console.WriteLine($"Tarefa {TaskNumber} removida com sucesso!");
                WaitForUserInput();
            }
            else
            {
                Console.WriteLine("Número inválido!");
                WaitForUserInput();
            }
        }

        static void Exit()
        {
            Console.WriteLine("Adeus!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void WaitForUserInput() // Função para aguardar o usuário digitar outra tarefa
        {
            Console.WriteLine("Digite outra tarefa ou pressione ENTER para sair: ");
            Console.ReadLine();
        }
    }
}