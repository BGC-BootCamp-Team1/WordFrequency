namespace WordFrequency.Tests
{
    public class WordFrequencyGameTest
    {
        [Fact]
        public void Should_get_the_1_when_input_the()
        {
            //Given
            string inputStr = "the";
            string expectResult = "the 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_two_words()
        {
            //Given
            string inputStr = "the is";
            string expectResult = "the 1\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_two_words_with_special_spaces()
        {
            //Given
            string inputStr = "the      is";
            string expectResult = "the 1\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        [Fact]
        public void Should_process_two_words_with_special_enter()
        {
            //Given
            string inputStr = "the   \n   is";
            string expectResult = "the 1\nis 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        //[Fact]
        //public void Should_pracess_two_same_words_with_sorted()
        //{
        //    //Given
        //    string inputStr = "the the is";
        //    string expectResult = "the 2\nis 1";
        //    Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        //}
        [Fact]
        public void Should_process_multiple_same_words_with_sorted()
        {
            //Given
            string inputStr = "the the the is is the the";
            string expectResult = "the 5\nis 2";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }


        [Fact]
        public void Should_process_sorted_with_count_descending()
        {
            //Given
            string inputStr = "the is is";
            string expectResult = "is 2\nthe 1";
            Validate_Input_words_process_to_expected_word(inputStr, expectResult);
        }

        private void Validate_Input_words_process_to_expected_word(string inputStr, string expectResult)
        {
            WordFrequencyGame game = new WordFrequencyGame();
            //When
            string actualResult = game.GetResult(inputStr);
            //Then
            Assert.Equal(expectResult, actualResult);
        }
    }
}
