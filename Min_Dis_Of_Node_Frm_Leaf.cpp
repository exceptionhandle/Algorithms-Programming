/* Find closest leaf to the given node x in a tree */
#include<bits/stdc++.h>
using namespace std;

// A Tree node
class Node
{
    private:
	int key;
	Node* left, *right;
	public:
	Node(int key){
	    this->key = key;
	    left = NULL;
	    right = NULL;
	}
	int getkey(){
	    return key;
	}
	Node* getLeft(){
	    return left;
	}
	Node* getRight(){
	    return right;
	}
	Node* setLeft(int x){
	    left = new Node(x);
	}
	Node* setRight(int x){
	    right = new Node(x);
	}
};

class minD{
    private:
    bool hasNode;
    int min;
    int disFrmNL;
    public:
    minD(){
        bool hasNode = false;
        int min = (1<<31)-1;
        disFrmNL = 0;
    }
    int getMinDis(){
        return min;
    }
    void setMinDis(int x)
    {
        this->min = x;
    }
    int setNode(){
        this->hasNode = true;
    }
    bool getNode(){
        return hasNode;
    }
    void setDisfrm(int x){
        this->disFrmNL = x;
    }
    void increDis(){
        this->disFrmNL++;
    }
    int getDisfrm(){
        return this->disFrmNL;
    }
};



// This function finds if there is closer leaf to x through 
// parent node.
minD* find(Node * root, Node *x)
{
    
	// Base cases
	if (root == NULL) return new minD;
    
    minD *L=find(root->getLeft(),x);
    minD* R=find(root->getRight(),x);

    // if the current root is the node that is being searched
    if(root == x){
        if(L->getDisfrm() <= R->getDisfrm()){
            L->setMinDis((L->getDisfrm()));
            L->setDisfrm(0);
            L->setNode();
            return L;
        }
        else{
            R->setMinDis(R->getDisfrm());
            R->setDisfrm(0);
            R->setNode();
            return R;
        }
    }
    // if the node is found in the left subtree
    else if(L->getNode()){
        int totalDis = L->getDisfrm()+R->getDisfrm()+1;
        int min = L->getMinDis();
        if(min>totalDis){
            cout<<"totalDis"<<totalDis<<endl;
            L->setMinDis(totalDis);
        }
        return L;
    }
    // if the node is found in the right subtree
    else if(R->getNode()){
        int totalDis = L->getDisfrm()+R->getDisfrm()+1;
        int min = R->getMinDis();
        if(min>totalDis){
            R->setMinDis(totalDis);
        }
        return R;
    }

    // if node is not found yet
    else if(!L->getNode()&&!R->getNode()){
        if(L->getDisfrm() < R->getDisfrm()){
            L->increDis();
            return L;
        }
        else{
            R->increDis();
            return R;
        }
    }
    
}
// Returns minimum distance of a leaf from given node x
int minimumDistance(Node *root, Node *x)
{
	// See if there is a closer leaf through parent
	minD *d = find(root, x);

	return d->getMinDis();
}

// Driver program
int main ()
{
	// Let us create Binary Tree shown in above example
	Node *root = new Node(1);
	root->setLeft(12);
	root->setRight(13);

	root->getRight()->setLeft(14);
	root->getRight()->setRight(15);

	root->getRight()->getLeft()->setLeft(21);
	root->getRight()->getLeft()->setRight(22);
	root->getRight()->getRight()->setLeft(23);
	root->getRight()->getRight()->setRight(24);

	root->getRight()->getLeft()->getLeft()->setLeft(1);
	root->getRight()->getLeft()->getLeft()->setRight(2);
	root->getRight()->getLeft()->getRight()->setLeft(3);
	root->getRight()->getLeft()->getRight()->setRight(4);
	root->getRight()->getRight()->getLeft()->setLeft(5);
	root->getRight()->getRight()->getLeft()->setRight(6);
	root->getRight()->getRight()->getRight()->setLeft(7);
	root->getRight()->getRight()->getRight()->setRight(8);

	Node *x = root->getRight();

	cout << "The closest leaf to the node with value "
		<< x->getkey() << " is at a distance of "
		<< minimumDistance(root, x) << endl;

	return 0;
}

