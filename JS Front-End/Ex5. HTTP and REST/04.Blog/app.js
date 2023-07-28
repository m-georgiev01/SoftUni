let posts;

function attachEvents() {
  document
    .querySelector('#btnLoadPosts')
    .addEventListener('click', loadAllPosts);

  document
    .querySelector('#btnViewPost')
    .addEventListener('click', loadSelectedPostsComments);
}

const API_URL = 'http://localhost:3030/jsonstore/blog';

function loadAllPosts() {
  fetch(`${API_URL}/posts`)
    .then((response) => response.json())
    .then((allPosts) => {
      posts = allPosts;

      const postsDropdown = document.querySelector('#posts');

      Object.values(allPosts).forEach((post) => {
        postsDropdown.appendChild(createOptionElement(post.id, post.title));
      });

      console.log(posts);
    });
}

function loadSelectedPostsComments() {
  fetch(`${API_URL}/comments`)
    .then((res) => res.json())
    .then((allComments) => {
      const selectedPost = posts[document.querySelector('#posts').value];

      const currentPostsComments = Object.values(allComments).filter(
        (comment) => comment.postId === selectedPost.id
      );

      document.querySelector('#post-title').textContent = selectedPost.title;
      document.querySelector('#post-body').textContent = selectedPost.body;

      const commentsContainer = document.querySelector('#post-comments');
      commentsContainer.innerHTML = '';

      currentPostsComments.forEach((postComment) => {
        const listItem = document.createElement('li');
        listItem.textContent = postComment.text;
        commentsContainer.appendChild(listItem);
      });
    });
}

function createOptionElement(value, text) {
  const option = document.createElement('option');
  option.value = value;
  option.textContent = text;

  return option;
}

attachEvents();
