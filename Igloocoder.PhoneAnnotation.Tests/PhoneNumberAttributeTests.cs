using NUnit.Framework;

namespace Igloocoder.PhoneAnnotation.Tests
{
    [TestFixture]
    public class When_verifying_a_phone_number
    {
        private PhoneNumberAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new PhoneNumberAttribute();
        }
        
        [Test]
        public void a_null_value_should_return_true()
        {
            var result = _attribute.IsValid(null);
            Assert.That(result, Is.True);
        }

        [Test]
        public void an_empty_string_should_return_true()
        {
            var result = _attribute.IsValid(string.Empty);
            Assert.That(result, Is.True);
        }

        [Test]
        public void a_white_space_string_should_return_true()
        {
            var result = _attribute.IsValid("  ");
            Assert.That(result, Is.True);
        }
    }

    [TestFixture]
    public class When_verifing_a_phone_number_for_one_region
    {
        private PhoneNumberAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new PhoneNumberAttribute("US");
        }
        [Test]
        public void a_valid_phone_number_should_pass()
        {
            var result = _attribute.IsValid("(780)456-9876");
            Assert.That(result, Is.True);
        }

        [Test]
        public void an_invalid_phone_number_shoul_fail()
        {
            var result = _attribute.IsValid("55 55 5555");
            Assert.That(result, Is.False);
        }
    }

    [TestFixture]
    public class When_verifying_a_phone_number_against_multiple_regions
    {
        private PhoneNumberAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new PhoneNumberAttribute(new []{"US","CH"});
        }
        [Test]
        public void a_phone_number_that_matches_one_of_the_regions_should_pass()
        {
            var result = _attribute.IsValid("044 668 18 00");
            Assert.That(result, Is.True);
        }

        [Test]
        public void a_phone_number_that_does_not_match_any_of_the_regions_should_fail()
        {
            var result = _attribute.IsValid("16 1234 5678");
            Assert.That(result, Is.False);
        }
    }

    [TestFixture]
    public class When_verifying_a_phone_number_and_no_region_is_assigned
    {
        private PhoneNumberAttribute _attribute;

        [SetUp]
        public void Setup()
        {
            _attribute = new PhoneNumberAttribute(new[] { "US" });
        }

        [Test]
        public void a_us_style_number_should_pass()
        {
            var result = _attribute.IsValid("1-780-999-7890");
            Assert.That(result, Is.True);
        }

        [Test]
        public void a_non_us_style_number_should_fail()
        {
            var result = _attribute.IsValid("044 668 18 00");
            Assert.That(result, Is.False);   
        }
    }
}