﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using  WordFrequency.Helpers;
using  ApprovalTests;
using ApprovalTests.Reporters;

namespace WordFrequency.UnitTests
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class WordCountTests
    {
        [Test]
        public void BlankReturnsEmptyDictionary()
        {
            Assert.That(WordCounter.GetWordCount(""),Is.EqualTo(new Dictionary<string,int>()));
        }
        [Test]
        public void OneWord()
        {
            Assert.That(WordCounter.GetWordCount("If"), Is.EqualTo(new Dictionary<string, int> {{"If", 1}}));
        }
        [Test]
        public void TwoWord()
        {
            Assert.That(WordCounter.GetWordCount("If starred"), Is.EqualTo(new Dictionary<string, int> { { "If", 1 },{"starred",1} }));
        }
        [Test]
        public void TwoOfSameWord()
        {
            Assert.That(WordCounter.GetWordCount("If If starred"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
        }
        [Test]
        public void TwoSeparatedWords()
        {
            Assert.That(WordCounter.GetWordCount("If starred If"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
        }
        [Test]
        public void IgnoreParens()
        {
//            Assert.That(WordCounter.GetWordCount("If (starred) If"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
            Approvals.VerifyAll(WordCounter.GetWordCount("If (starred) If"));
        }
        [Test]
        public void IgnoreBraces()
        {
            //            Assert.That(WordCounter.GetWordCount("If (starred) If"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
            Approvals.VerifyAll(WordCounter.GetWordCount("If [starred] If"));
        }
        [Test]
        public void IgnoreCurlyBraces()
        {
            //            Assert.That(WordCounter.GetWordCount("If (starred) If"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
            Approvals.VerifyAll(WordCounter.GetWordCount("If {starred} If"));
        }
        [Test]
        public void CaseSensitive()
        {
            //            Assert.That(WordCounter.GetWordCount("If (starred) If"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
            Approvals.VerifyAll(WordCounter.GetWordCount("If {starred} if"));
        }
        [Test]
        public void IfElseStatement()
        {
            string test = @"if (retDictionary.ContainsKey(word))
            {
                retDictionary[word]++;
            }
            else
            {
                retDictionary.Add(word, 1);
            }";
            //            Assert.That(WordCounter.GetWordCount("If (starred) If"), Is.EqualTo(new Dictionary<string, int> { { "If", 2 }, { "starred", 1 } }));
            Approvals.VerifyAll(WordCounter.GetWordCount(test));
        }
        [Test]
        public void IgnoresNumbers()
        {
            string test = @"one 1";
            Assert.That(WordCounter.GetWordCount(test), Is.EqualTo(new Dictionary<string, int> { { "one", 1 } }));
        }
        [Test]
        public void IncludesUnderscoreVariables()
        {
            string test = @"_Local";
            Assert.That(WordCounter.GetWordCount(test), Is.EqualTo(new Dictionary<string, int> { { "_Local", 1 } }));
        }
        [Test]
        public void QuotedLiterals()
        {
            string test = "var mySentence = \"the test\"";
            Assert.That(WordCounter.GetWordCount(test), Is.EqualTo(new Dictionary<string, int> { { "var", 1 }, { "mySentence", 1 }, { "the", 1 }, { "test", 1 } }));
        }
        [Test]
        public void OrderResults1()
        {
            string test = "this happy test is test test is";
            //Approvals.VerifyAll(WordCounter.GetWordCount(test));
            Assert.That(WordCounter.GetWordCount(test), Is.EqualTo(new Dictionary<string, int> { { "test", 3 }, { "is", 2 }, {"happy", 1}, { "this", 1 } }));
        }
        [Test]
        public void OrderResults2()
        {
            string test = "is test test is test this";
            //Approvals.VerifyAll(WordCounter.GetWordCount(test));
            Assert.That(WordCounter.GetWordCount(test), Is.EqualTo(new Dictionary<string, int> { { "test", 3 }, { "is", 2 }, { "this", 1 } }));
        }
    }
}
