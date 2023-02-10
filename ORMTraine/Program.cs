using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMTraine
{
    class Program
    {
       
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                #region Groups create
                var group = new Group()
                {
                    Name = "Rammstain",
                    Year = 1994
                };

                var group2 = new Group()
                {
                    Name = "Linkin Park",
                    Year = 1996
                };

                var group3 = new Group()
                {
                    Name = "Miyagi",
                    Year = 2015
                };
                #endregion

                #region Groups add and save changes
                context.Groups.Add(group);
                context.Groups.Add(group2);
                context.Groups.Add(group3);
                context.SaveChanges();
                #endregion

                #region Songs create, add and save changes
                var songs = new List<Song>
                {
                    new Song() {Name = "In the end", GroupId = group2.Id  },
                    new Song() {Name = "Matter", GroupId = group.Id },
                    new Song() {Name = "Сын", GroupId = group3.Id  },
                    new Song() {Name = "Малиновый рассвет", GroupId = group3.Id  }

                };

                context.Songs.AddRange(songs);
                context.SaveChanges();
                #endregion

                #region Как изменить названи свойства
                var changeName = context.Groups.Single(x => x.Id == group3.Id);
                changeName.Name = "Miyagi Эндшпиль";
                context.SaveChanges();
                #endregion
            }

            #region Команды для "Консоль деспетчера пакетов"
            /*
             Команды для "Консоль деспетчера пакетов":
             
            1. enable-migrations - Пишется после создания таблицы, для устранения неполадок при изминении структуры таблицы.
               Писать нужно только один раз при создании бд.
            2. add-migration Addназваниегруппы и нового свойста (AddGroupType) пишется после добавления изминения в структуре таблицы
            3. update-datase пишется после каждого внесения изменения (add-migration) обновляет базу данных.         
            
             */
            #endregion

            #region Как вытянуть данные из таблицы
            var context2 = new MyDbContext();

            var listgroup = new List<Group>();
            foreach (Group group1 in context2.Groups)
            {
                listgroup.Add(group1);
            }

            //это тоже самое что и код выше 
            var listgroup1 = context2.Groups.ToList();
            foreach (var item in listgroup1)
            {
                Console.WriteLine(item.Name); 
            }
            #endregion                                   

            #region ДЗ
            /* ДЗ
             * 1. Создать ORM таблицу в своей предметной обсласти.
             * 2. Реализовать запись, чтение, изменение, и удаление данных.
             */
            #endregion





        }
    }
}
