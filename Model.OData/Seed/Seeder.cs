using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.OData.Seed
{
    public class Seeder
    {
        private readonly DbContext _Context;

        private School[] _Schools;
        private School[] Schools
        {
            get
            {
                if (_Schools == null)
                {
                    _Schools = new School[] {
                        new School {
                            Id = new Guid("3bef4e0a-8be9-435c-98fe-25508a988b7b"),
                            Name = "School 1"
                        },
                        new School {
                            Id = new Guid("7dd15973-0363-40f6-ba0e-cc3ac668aed8"),
                            Name = "School 2"
                        }
                    };
                }

                return _Schools;
            }
        }

        private Student[] _Students;
        private Student[] Students
        {
            get
            {
                if (_Students == null)
                {
                    Random rand = new Random();
                    _Students = new Student[] {
                        new Student {
                            Id = new Guid("fc0d5922-5cac-43e3-bb5f-d7e1e15f5240"),
                            Name = "Bradleigh Osborn",
                            Age = rand.Next(10, 18)
                        },
                        new Student {
                            Id = new Guid("d9683c4d-1b62-4071-a847-224d1d2e6040"),
                            Name = "Hasnain Regan",
                            Age = rand.Next(10, 18)
                        },
                        new Student {
                            Id = new Guid("b1f24018-f350-44e6-8e96-f419adc69bc9"),
                            Name = "Joan Chen",
                            Age = rand.Next(10, 18)
                        },
                        new Student {
                            Id = new Guid("f1b3e9b2-49e9-49ee-8035-a268f1b1050d"),
                            Name = "Mariana Estes",
                            Age = rand.Next(10, 18)
                        },
                        new Student {
                            Id = new Guid("07e6820d-5a1c-4ca0-a16a-9f7a3f73efb0"),
                            Name = "Vinny Little",
                            Age = rand.Next(10, 18)
                        },
                        new Student {
                            Id = new Guid("42eef36a-343c-40cc-95ae-5d412e37cc26"),
                            Name = "Yousaf Hurst",
                            Age = rand.Next(10, 18)
                        },
                        new Student {
                            Id = new Guid("824190b5-aa86-4693-a443-d8753137bb0a"),
                            Name = "Harry Andrew",
                            Age = rand.Next(10, 18)
                        }
                    };
                }

                return _Students;
            }
        }

        private Teacher[] _Teachers;
        private Teacher[] Teachers
        {
            get
            {
                if (_Teachers == null)
                {
                    _Teachers = new Teacher[] {
                        new Teacher {
                            Id = new Guid("cb22187f-0eb8-4620-a828-0fd1bd078a3d"),
                            Name = "Karl Gilmore",
                        },
                        new Teacher {
                            Id = new Guid("fd8c352f-0518-4acd-8425-4b6138d7780e"),
                            Name = "Shakira Chung",
                        },
                        new Teacher {
                            Id = new Guid("2ea661f7-0e11-4639-b38e-503510f4c1d7"),
                            Name = "Isla-Grace Green",
                        }
                    };
                }

                return _Teachers;
            }
        }

        public Seeder(DbContext context)
        {
            _Context = context;
        }

        public void Runner()
        {
            if (_Context.Set<School>().AnyAsync().GetAwaiter().GetResult())
            {
                return;
            }

            _Context.Set<Student>().AddRange(Students);
            List<TeacherStudents> TeacherStudents = new List<TeacherStudents>();
            for (int i = 0; i < Students.Length; i++)
            {
                Schools[i % 2].Students.Add(Students[i]);
                TeacherStudents.Add(new TeacherStudents {
                    StudentId = Students[i].Id,
                    TeacherId = Teachers[i % Teachers.Length].Id
                });
            }

            _Context.Set<Teacher>().AddRange(Teachers);
            for (int i = 0; i < Teachers.Length; i++)
            {
                Schools[i % 2].Teachers.Add(Teachers[i]);
            }

            _Context.Set<TeacherStudents>().AddRange(TeacherStudents);
            _Context.Set<School>().AddRange(Schools);
            _Context.SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
