using Itmo.ObjectOrientedProgramming.Lab2.ContentCreation;
using Itmo.ObjectOrientedProgramming.Lab2.Labworks;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Lab2.Tests;

public class EducationProgramTests
{
    [Fact]
    public void NonAuthor_Cannot_Update_Lection()
    {
        var userFactory = new UserFactory();
        IUser author = userFactory.CreateUser("Роман Макаревич");
        IUser nonAuthor = userFactory.CreateUser("Я делал эту лабу дольше, чем мог");

        var lectionRepository = new LectionsRepository();
        var lection = new Lection("Лекция 52", "Описание", "Контент", author);
        lectionRepository.Add(lection);

        Result result = lection.Edit(
            "Обновленное название",
            "Обновленное описание",
            "Обновленное содержание",
            nonAuthor);

        Assert.IsType<Result.WrongAuthor>(result);
    }

    [Fact]
    public void NonAuthor_Cannot_Update_Labwork()
    {
        var userFactory = new UserFactory();
        IUser author = userFactory.CreateUser("Хвост");
        IUser nonAuthor = userFactory.CreateUser("Боже какой я лох");

        var labworkRepository = new LabworksRepository();
        var labwork = new Labwork("Лабораторная 52", "Описание", "Критерии", 10, author);
        labworkRepository.Add(labwork);

        Result result = labwork.Edit(
            "Обновленное название",
            "Обновленное описание",
            "Обновленные критерии",
            nonAuthor);

        Assert.IsType<Result.WrongAuthor>(result);
    }

    [Fact]
    public void Cloned_Lection_Has_Original_Id()
    {
        var userFactory = new UserFactory();
        IUser author = userFactory.CreateUser("Роман Макаревич");

        var originalLection = new Lection("Лекция 52", "Описание", "Контент", author);

        Lection clonedLection = originalLection.Clone();

        Assert.Equal(originalLection.Id, clonedLection.ParentId);
        Assert.NotEqual(originalLection.Id, clonedLection.Id);
    }

    [Fact]
    public void Cloned_Labwork_Has_Original_Id()
    {
        var userFactory = new UserFactory();
        IUser author = userFactory.CreateUser("Автор Лабораторной");

        var originalLabwork = new Labwork("Лабораторная 52", "Описание", "Критерии", 10, author);

        Labwork clonedLabwork = originalLabwork.Clone();

        Assert.Equal(originalLabwork.Id, clonedLabwork.ParentId);
        Assert.NotEqual(originalLabwork.Id, clonedLabwork.Id);
    }

    [Fact]
    public void Creating_Subject_With_Invalid_Total_Points_Throws_Exception()
    {
        var userFactory = new UserFactory();
        IUser author = userFactory.CreateUser("Автор Предмета");

        var materialsFactory = new ContentFactory();
        Lection lection = materialsFactory.CreateLection(
            "Лекция 52",
            "Описание",
            "Содержание",
            author);
        Labwork labwork = materialsFactory.CreateLabwork(
            "Лабораторная 52",
            "Описание",
            "Критерии",
            10,
            author);

        var lections = new List<Lection> { lection };
        var labworks = new List<Labwork> { labwork };

        Assert.Throws<InvalidOperationException>(() =>
        {
            ISubject subject = Subject.Builder.WithAuthor(author)
                .WithIsExam(true)
                .WithName("ООП")
                .WithLabworks(labworks)
                .WithLections(lections)
                .WithExamScore(900)
                .Build();
        });
    }

    [Fact]
    public void Adding_Duplicate_User_Throws_Exception()
    {
        var userFactory = new UserFactory();
        IUser user = userFactory.CreateUser("Дубликат Пользователя");
        var userRepository = new UsersRepository();
        userRepository.Add(user);

        Assert.Throws<ArgumentException>(() => userRepository.Add(user));
    }

    [Fact]
    public void Get_User_By_Invalid_Id_Returns_Null()
    {
        var userRepository = new UsersRepository();
        var invalidId = Guid.NewGuid();

        IUser? user = userRepository.GetById(invalidId);

        Assert.Null(user);
    }

    [Fact]
    public void Get_Labwork_By_Invalid_Id_Returns_Null()
    {
        var labworkRepository = new LabworksRepository();
        var invalidId = Guid.NewGuid();

        Labwork? labwork = labworkRepository.GetById(invalidId);

        Assert.Null(labwork);
    }
}