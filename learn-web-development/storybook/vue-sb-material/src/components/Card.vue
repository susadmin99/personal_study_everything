<template>
    <div class="card">
        <h4 class="title"> {{title}} </h4>
        <p class="secondary-text"> {{subText}} </p>
    </div>
</template>
<script>
export default {
    name: 'Card',
    props: {
        title: String,
        subText: String
    }
}
</script>
<style scoped>
    .card {
        background-color: #fff;
        border-radius: .2rem;
        box-shadow: rgb(150, 150, 150) 0px 1px 3px;
        width: 350px;
        padding: .8rem;
    }
</style>