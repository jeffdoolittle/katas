﻿using System;
using FluentAssertions;
using Xunit;

namespace TennisKata
{
    public class tennis_score_keeper_fixture
    {
        protected TennisScoreKeeper ClassUnderTest;

        public tennis_score_keeper_fixture()
        {
            ClassUnderTest = new TennisScoreKeeper();
        }

        [Fact]
        public void when_game_begins_score_is_luv_to_luv()
        {
            ClassUnderTest.CurrentScore.Should().Be("Luv-Luv");
        }

        [Fact]
        public void when_player_one_earns_a_point_score_is_fifteen_luv()
        {
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.CurrentScore.Should().Be("Fifteen-Luv");
        }

        [Fact]
        public void when_player_two_earns_a_point_score_is_luv_fifteen()
        {
            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.CurrentScore.Should().Be("Luv-Fifteen");
        }

        [Fact]
        public void when_player_one_earns_two_points_score_is_thirty_luv()
        {
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.CurrentScore.Should().Be("Thirty-Luv");
        }

        [Fact]
        public void when_player_one_earns_three_points_score_is_forty_luv()
        {
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.CurrentScore.Should().Be("Forty-Luv");
        }

        [Fact]
        public void when_player_one_earns_four_points_game_is_over_with_player_one_the_winner()
        {
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.CurrentScore.Should().Be("Player One wins!");
        }

        [Fact]
        public void when_players_are_tied_at_forty_score_is_deuce()
        {
            ClassUnderTest.PointForPlayerOne(); 
            ClassUnderTest.PointForPlayerOne(); 

            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.CurrentScore.Should().Be("Deuce");
        }

        [Fact]
        public void when_player_one_has_one_point_above_deuce_score_is_advantage_player_one()
        {
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.PointForPlayerTwo();
            
            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.CurrentScore.Should().Be("Advantage Player One");
        }

        [Fact]
        public void when_player_two_has_one_point_above_deuce_score_is_advantage_player_two()
        {
            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.CurrentScore.Should().Be("Advantage Player Two");
        }

        [Fact]
        public void when_player_two_has_one_point_above_deuce_then_player_one_scores_again_score_is_deuce()
        {
            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();
            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.PointForPlayerTwo();

            ClassUnderTest.PointForPlayerOne();

            ClassUnderTest.CurrentScore.Should().Be("Deuce");
        }

        [Fact]
        public void when_game_is_over_but_points_are_added()
        {
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();
            ClassUnderTest.PointForPlayerOne();

            ((Action)(() => ClassUnderTest.PointForPlayerTwo())).ShouldThrow<InvalidOperationException>();
        }
    }
}