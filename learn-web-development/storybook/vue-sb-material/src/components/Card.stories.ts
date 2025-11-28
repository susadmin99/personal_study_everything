import type { Meta, StoryObj } from '@storybook/vue3';

import Component from './Card.vue';

const meta: Meta<typeof Component> = {
  component: Component,
};

//👇 This default export determines where your story goes in the story list
export default meta;
type Story = StoryObj<typeof Component>;


export const Primary: Story = {
  render: (args) => ({
    components: { Component },
    setup() {
      return { args };
    },
    template: '<YourComponent v-bind="args" />',
  }),
  args: {
    title: 'Primary',
    subText: 'Example sub text'
  },
};