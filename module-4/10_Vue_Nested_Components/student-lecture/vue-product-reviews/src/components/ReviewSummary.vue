<template>
    <div class="well-display">
        <div class="well">
            <span class="amount" v-on:click="filter(0)">{{ averageRating }}</span>
            Average Rating
        </div>

        <div class="well">
            <span class="amount" v-on:click="filter(1)">{{ numberOfOneStarReviews }}</span>
            1 Star Review{{ numberOfOneStarReviews === 1 ? '' : 's' }}
        </div>

        <div class="well">
            <span class="amount"  v-on:click="filter(2)">{{ numberOfTwoStarReviews }}</span>
            2 Star Review{{ numberOfTwoStarReviews === 1 ? '' : 's' }}
        </div>

        <div class="well">
            <span class="amount"  v-on:click="filter(3)">{{ numberOfThreeStarReviews }}</span>
            3 Star Review{{ numberOfThreeStarReviews === 1 ? '' : 's' }}
        </div>

        <div class="well">
            <span class="amount"  v-on:click="filter(4)">{{ numberOfFourStarReviews }}</span>
            4 Star Review{{ numberOfFourStarReviews === 1 ? '' : 's' }}
        </div>

        <div class="well">
            <span class="amount"  v-on:click="filter(5)">{{ numberOfFiveStarReviews }}</span>
            5 Star Review{{ numberOfFiveStarReviews === 1 ? '' : 's' }}
        </div>
    </div>
</template>

<script>
    export default {    
        name: 'review-summary',
        computed: {
            averageRating() {
                let sum = this.reviews.reduce( (currentSum, review) => {
                    return currentSum + review.rating;
                }, 0);
                return sum / this.reviews.length;
            },
            numberOfOneStarReviews() {
                return this.numberOfReviews(1);
            },
            numberOfTwoStarReviews() {
                return this.numberOfReviews(2);
            },
            numberOfThreeStarReviews() {
                return this.numberOfReviews(3);
            },
            numberOfFourStarReviews() {
                return this.numberOfReviews(4);
            },
            numberOfFiveStarReviews() {
                return this.numberOfReviews(5);
            },
        },
        props: {
            reviews: Array
        },
        methods: {
            numberOfReviews(starType) {
                return this.reviews.reduce( (currentCount, review ) => {
                    return currentCount + ( review.rating === starType ? 1 : 0);
                }, 0);
            },
            filter(starType) {
                this.$emit('filter-reviews', starType);
            }
        }
    }
</script>

<style scoped>
    div.well-display {
        display: flex;
        justify-content: space-around;
    }

    div.well-display div.well {
        display: inline-block;
        width: 15%;
        border: 1px black solid;
        border-radius: 6px;
        text-align: center;
        margin: 0.25rem;
    }
    
    span.amount {
        color: darkslategray;
        display: block;
        font-size: 2.5rem;
        cursor: pointer;
    }
</style>