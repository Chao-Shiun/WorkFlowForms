<template>
  <div id="app">
    <div class="sidebar" @mouseover="showMenu" @mouseleave="hideMenu">
      <ul v-if="menuVisible">
        <li v-for="item in menu" :key="item.name">
          <a href="#">{{ item.name }}</a>
          <ul v-if="item.children">
            <li v-for="child in item.children" :key="child.name">
              <a href="#">{{ child.name }}</a>
              <ul v-if="child.children">
                <li v-for="subChild in child.children" :key="subChild.name">
                  <a href="#">{{ subChild.name }}</a>
                </li>
              </ul>
            </li>
          </ul>
        </li>
      </ul>
    </div>
    <div class="content">
      <h1>Welcome to WorkFlowForms</h1>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      menuVisible: false,
      menu: [
        {
          name: 'Menu 1',
          children: [
            {
              name: 'Submenu 1-1',
              children: [
                { name: 'Submenu 1-1-1' },
                { name: 'Submenu 1-1-2' }
              ]
            },
            { name: 'Submenu 1-2' }
          ]
        },
        { name: 'Menu 2' }
      ]
    };
  },
  methods: {
    showMenu() {
      this.menuVisible = true;
    },
    hideMenu() {
      this.menuVisible = false;
    }
  }
};
</script>

<style>
#app {
  display: flex;
}
.sidebar {
  width: 20%;
  background-color: #f4f4f4;
  position: fixed;
  left: -20%;
  transition: left 0.3s;
}
.sidebar:hover {
  left: 0;
}
.content {
  margin-left: 20%;
  width: 80%;
  padding: 20px;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  padding: 8px 16px;
}
a {
  text-decoration: none;
  color: #333;
}
</style> 