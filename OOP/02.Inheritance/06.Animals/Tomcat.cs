﻿namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatGender = "male";
        public Tomcat(string name, int age) : base(name, age, TomcatGender)
        {
            base.Sound = "MEOW";
        }
    }
}
